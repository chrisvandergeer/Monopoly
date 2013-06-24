using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.domein
{
    public interface IGebeurtenis
    {
        //Gebeurtenisresult Result { get; }
        string Naam { get; }
        bool IsVerplicht();
        //bool IsUitgevoerd();
        //bool IsVerplichtEnNietUitgevoerd();
        bool IsUitvoerbaar(Speler speler);
        void Voeruit(Speler speler);
    }
}
