using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.domein.gebeurtenissen
{
    abstract public class Gebeurtenis : IGebeurtenis
    {
        //public Gebeurtenisresult Result { get; private set; }
        public string Naam { get; private set; }

        public Gebeurtenis(string naam)
        {
            Naam = naam;
        }

        abstract public bool IsVerplicht();
        abstract public bool IsUitvoerbaar(Speler speler);
        abstract public void Voeruit(Speler speler);

        public override bool Equals(object obj)
        {
            if (obj is Gebeurtenis)
            {
                string otherNaam = ((Gebeurtenis) obj).Naam;
                return Naam == null ? otherNaam == null : Naam.Equals(otherNaam);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Naam == null ? 0 : Naam.GetHashCode();
        }

        public override string ToString()
        {
            return Naam;
        }

        public Gebeurtenisresult SetResult(Gebeurtenislijst beurtGebeurtenissen, params object[] tekst)
        {
            Gebeurtenisresult result = new Gebeurtenisresult();
            result.SetUitgevoerd(tekst);
            beurtGebeurtenissen.VoegResultToe(result);
            return result;
        }
    }
}
