using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.domein.gebeurtenissen
{
    class BetaalGeld : Gebeurtenis
    {
        private int Bedrag { get; set; }
        private Speler Begunstigde { get; set; }
        private string Tekst { get; set; }

        public BetaalGeld(int bedrag, Speler begunstigde)
            : base(Gebeurtenisnamen.BETAAL_GELD)
        {
            Bedrag = bedrag;
            Begunstigde = begunstigde;
        }

        public BetaalGeld(int bedrag)
            : base(Gebeurtenisnamen.BETAAL_GELD)
        {
            Bedrag = bedrag;
            Begunstigde = Monopolyspel.BANK;
        }


        public BetaalGeld SetTekst(string tekst)
        {
            Tekst = tekst;
            return this;
        }

        public override bool IsVerplicht()
        {
            return true;
        }

        public override bool IsUitvoerbaar(Speler speler)
        {
            return speler.Bezittingen.Kasgeld >= Bedrag;
        }

        public override void Voeruit(Speler speler)
        {
            speler.Bezittingen.Betaal(Bedrag, Begunstigde);
            string tekst = Tekst != null ? Tekst : Naam;
            SetResult(speler.BeurtGebeurtenissen, tekst);
            speler.BeurtGebeurtenissen.VerwijderGebeurtenis(this);
        }

    }
}
