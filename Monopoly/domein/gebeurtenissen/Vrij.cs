using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.domein.gebeurtenissen
{
    public class Vrij : Gebeurtenis
    {
        private string Tekst { get; set; }

        public Vrij(string tekst)
            : base(Gebeurtenisnamen.VRIJ)
        {
            Tekst = tekst;
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
            SetResult(speler.BeurtGebeurtenissen, Tekst);
            speler.BeurtGebeurtenissen.VerwijderGebeurtenis(this);
        }
    }
}
