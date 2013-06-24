using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.gebeurtenissen;
using Monopoly.domein;

namespace Monopoly.AI
{
    public interface IDecision
    {
        bool decide(Speler speler, IGebeurtenis gebeurtenis);
    }
}
