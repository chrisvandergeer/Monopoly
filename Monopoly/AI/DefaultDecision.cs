using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.gebeurtenissen;
using Monopoly.domein;

namespace Monopoly.AI
{
    public class DefaultDecision : IDecision
    {
        public bool decide(Speler speler, IGebeurtenis gebeurtenis)
        {
            return true;
        }
    }
}
