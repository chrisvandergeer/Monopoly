using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.domein.gebeurtenissen
{
    public class OntvangGeld : Gebeurtenis
    {
        private int Bedrag { get; set; }
        private string Tekst { get; set; }

        public OntvangGeld(int bedrag) : base(Gebeurtenisnamen.BETAAL_GELD)
        {
            Bedrag = bedrag;
        }

        public OntvangGeld SetTekst(string tekst)
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
            return true;
        }

        public override void Voeruit(Speler speler)
        {
            speler.Bezittingen.OntvangGeld(Bedrag);
            string tekst = Tekst != null ? Tekst : Naam;
            SetResult(speler.BeurtGebeurtenissen, tekst);
            speler.BeurtGebeurtenissen.VerwijderGebeurtenis(this);
        }
    }
}
