using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.velden;

namespace Monopoly.domein.gebeurtenissen
{
    class NeemHypotheek : Gebeurtenis
    {
        public NeemHypotheek() : base(Gebeurtenisnamen.NEEM_HYPOTHEEK) { }

        public override bool IsVerplicht()
        {
            return false;
        }

        public override bool IsUitvoerbaar(Speler speler)
        {
            return speler.Bezittingen.Straten().Exists(straat => !straat.Hypotheek.IsOnderHypotheek);
        }

        public override void Voeruit(Speler speler)
        {
            IHypotheekveld veld = speler.Bezittingen.Hypotheekvelden.FindLast(str => !str.Hypotheek.IsOnderHypotheek);
            veld.Hypotheek.NeemHypotheek();
            SetResult(speler.BeurtGebeurtenissen, speler, "neemt hypotheek op", veld);
        }
    }
}
