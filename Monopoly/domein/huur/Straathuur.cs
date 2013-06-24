using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.velden;

namespace Monopoly.domein
{
    public class Straathuur : IHuurprijsBepaler
    {
        private List<int> Huurprijzen { get; set; }

        public Straathuur(int huurOnbebouwd, int huurMet1Huis, int huurMet2Huizen, int huurMet3Huizen, int huurMet4Huizen, int huurMetHotel)
        {
            Huurprijzen = new List<int>();
            Huurprijzen.Add(huurOnbebouwd);
            Huurprijzen.Add(huurMet1Huis);
            Huurprijzen.Add(huurMet2Huizen);
            Huurprijzen.Add(huurMet3Huizen);
            Huurprijzen.Add(huurMet4Huizen);
            Huurprijzen.Add(huurMetHotel);
        }

        public int BepaalHuurprijs(IHypotheekveld veld)
        {
            int aantalHuizen = ((Straat)veld).AantalHuizen;
            return Huurprijzen[aantalHuizen];
        }
    }
}
