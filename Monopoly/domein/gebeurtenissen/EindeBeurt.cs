using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.domein.gebeurtenissen
{
    public class EindeBeurt : Gebeurtenis
    {
        public EindeBeurt() : base(Gebeurtenisnamen.EINDE_BEURT) { }

        public override bool IsVerplicht()
        {
            return false;
        }

        public override bool IsUitvoerbaar(Speler speler)
        {
            return !speler.BeurtGebeurtenissen.BevatNogUitTeVoerenVerplichteGebeurtenissen();
        }

        public override void Voeruit(Speler speler)
        {
            speler.BeurtGebeurtenissen.VerwijderNogUitTeVoerenGebeurtenissen();
            SetResult(speler.BeurtGebeurtenissen, speler, "heeft beurt beeindigd, kasgeld: " + speler.Bezittingen.Kasgeld, ", aantal straten: " + speler.Bezittingen.Straten().Count);
            speler.BeurtGebeurtenissen.VerwijderGebeurtenis(this);
        }

    }
}
