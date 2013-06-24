using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.velden;

namespace Monopoly.domein.gebeurtenissen
{
    public class LosHypotheekAf : Gebeurtenis
    {

        public LosHypotheekAf() : base(Gebeurtenisnamen.LOS_HYPOTHEEK_AF) { }

        public override bool IsVerplicht()
        {
            return false;
        }

        public override bool IsUitvoerbaar(Speler speler)
        {
            if (speler.BeurtGebeurtenissen.BevatNogUitTeVoerenVerplichteGebeurtenissen())
                return false;
            IHypotheekveld straat = speler.Bezittingen.Hypotheekvelden.FindLast(str => str.Hypotheek.IsOnderHypotheek);
            return straat == null ? false : straat.Hypotheek.HypotheekAflosbedrag() < speler.Bezittingen.Kasgeld;
        }

        public override void Voeruit(Speler speler)
        {
            IHypotheekveld straat = speler.Bezittingen.Hypotheekvelden.FindLast(entry => entry.Hypotheek.IsOnderHypotheek);
            straat.Hypotheek.LosHypotheekAf();
            SetResult(speler.BeurtGebeurtenissen, speler, "lost hypotheek af van", straat);
        }
    }
}
