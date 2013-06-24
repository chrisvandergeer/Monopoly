using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.velden;

namespace Monopoly.domein.gebeurtenissen
{
    class KoopStraat : Gebeurtenis
    {
        private IHypotheekveld TeKopenVeld { get; set; }

        public KoopStraat(IHypotheekveld straat) : base(Gebeurtenisnamen.KOOP_STRAAT)
        {
            TeKopenVeld = straat;
        }

        public override bool IsVerplicht()
        {
            return false;
        }

        public override bool IsUitvoerbaar(Speler speler)
        {
            return TeKopenVeld.Koopprijs <= speler.Bezittingen.Kasgeld;
        }

        public override void Voeruit(Speler speler)
        {
            Gebeurtenislijst gebeurtenissen = speler.BeurtGebeurtenissen;
            if (TeKopenVeld.Verkoop(speler))
            {
                SetResult(gebeurtenissen, speler, "koopt", TeKopenVeld);
                speler.BeurtGebeurtenissen.VerwijderGebeurtenis(this);
            }
            else
                SetResult(gebeurtenissen, speler, "heeft onvoldoende geld om ", TeKopenVeld, "te kopen");
        }
    }
}
