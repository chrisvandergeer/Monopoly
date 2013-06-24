using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein;

namespace Monopoly.AI
{
    public class KoopHuisDecision : IDecision
    {
        public bool decide(Speler speler, IGebeurtenis gebeurtenis)
        {
            bool decision = speler.Bezittingen.Kasgeld > 100;
            return decision;
        }
    }
}
