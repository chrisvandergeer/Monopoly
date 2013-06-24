using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.velden;

namespace Monopoly.domein.gebeurtenissen
{
    class BetaalHuur : Gebeurtenis
    {
        private IHypotheekveld HuurObject { get; set; }

        public BetaalHuur(IHypotheekveld huurobject) : base(Gebeurtenisnamen.BETAAL_HUUR)
        {
            HuurObject = huurobject;
        }

        public override bool IsVerplicht()
        {
            return true;
        }

        public override bool IsUitvoerbaar(Speler speler)
        {
            return HuurObject.BepaalHuurprijs() <= speler.Bezittingen.Kasgeld;
        }

        public override void Voeruit(Speler speler)
        {
            int huurprijs = HuurObject.BepaalHuurprijs();
            Speler eigenaar = HuurObject.Eigenaar;
            if (speler.Bezittingen.Betaal(huurprijs, eigenaar))
            {
                SetResult(speler.BeurtGebeurtenissen, speler, "betaald", huurprijs, "huur aan", eigenaar);
                speler.BeurtGebeurtenissen.VerwijderGebeurtenis(this);
            }
            else
                SetResult(speler.BeurtGebeurtenissen, speler, "heeft niet voldoende kasgeld om ", huurprijs, "aan", eigenaar, "te betalen");
        }        
    }
}
