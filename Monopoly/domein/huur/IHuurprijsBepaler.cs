using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.velden;

namespace Monopoly.domein
{
    public interface IHuurprijsBepaler
    {
        int BepaalHuurprijs(IHypotheekveld veld);
    }
}
