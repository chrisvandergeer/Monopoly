using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.domein
{
    public interface IGebeurtenis
    {
        string Naam { get; }
        bool IsVerplicht();
        bool IsUitvoerbaar(Speler speler);
        void Voeruit(Speler speler);
    }
}
