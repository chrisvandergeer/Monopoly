using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.domein
{
    public interface IVeld
    {
        string Naam { get; }
        IGebeurtenis BepaalGebeurtenis();
    }
}
