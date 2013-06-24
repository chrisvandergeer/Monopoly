using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.velden;
using Monopoly.builders;
using Monopoly.domein.labels;

namespace Monopoly.domein
{
    public class Spelbord
    {
        public List<Veld> Velden { get; private set; }

        public Spelbord()
        {
            Velden = new List<Veld>();
            Gebeurtenisveldbuilder gebeurtenisveldBuilder = new Gebeurtenisveldbuilder();
            Straatbuilder straatbuilder = new Straatbuilder().Build();
            StationEnNutsBuilder stationbuilder = new StationEnNutsBuilder();
            Velden.Add(gebeurtenisveldBuilder.BuildStart());
            Velden.Add(straatbuilder.Naam(Veldnamen.DORPSSTRAAT));
            // Algemeen Fonds
            Velden.Add(straatbuilder.Naam(Veldnamen.BRINK));
            Velden.Add(gebeurtenisveldBuilder.BuildInkomstenBelasting());
            Velden.Add(stationbuilder.buildStationZuid());
            Velden.Add(straatbuilder.Naam(Veldnamen.STEENSTRAAT));
            // Kans
            Velden.Add(straatbuilder.Naam(Veldnamen.KETELSTRAAT));
            Velden.Add(straatbuilder.Naam(Veldnamen.VELPERPLEIN));
            // Gevangenis
            Velden.Add(straatbuilder.Naam(Veldnamen.BARTELJORISSTRAAT));
            Velden.Add(stationbuilder.buildNutsElektriciteit());
            Velden.Add(straatbuilder.Naam(Veldnamen.ZIJLWEG));
            Velden.Add(straatbuilder.Naam(Veldnamen.HOUTSTRAAT));
            Velden.Add(stationbuilder.buildStationWest());
            Velden.Add(straatbuilder.Naam(Veldnamen.NEUDE));
            // Algeen Fonds
            Velden.Add(straatbuilder.Naam(Veldnamen.BILTSTRAAT));
            Velden.Add(straatbuilder.Naam(Veldnamen.VREEBURG));
            // Vrij parkeren
            Velden.Add(straatbuilder.Naam(Veldnamen.AKERKHOF));
            // Kans
            Velden.Add(straatbuilder.Naam(Veldnamen.GROTE_MARKT));
            Velden.Add(straatbuilder.Naam(Veldnamen.HEERESTRAAT));
            Velden.Add(stationbuilder.buildStationNoord());
            Velden.Add(straatbuilder.Naam(Veldnamen.SPUI));
            Velden.Add(straatbuilder.Naam(Veldnamen.PLEIN));
            Velden.Add(stationbuilder.buildNutsWaterleiding());
            Velden.Add(straatbuilder.Naam(Veldnamen.LANGE_POTEN));
            // Naar de gevangenis
            Velden.Add(straatbuilder.Naam(Veldnamen.HOFPLEIN));
            Velden.Add(straatbuilder.Naam(Veldnamen.BLAAK));
            // Algemeen Fonds
            Velden.Add(straatbuilder.Naam(Veldnamen.COOLSINGEL));
            Velden.Add(stationbuilder.buildStationOost());
            // Kans
            Velden.Add(straatbuilder.Naam(Veldnamen.LEIDSCHESTRAAT));
            Velden.Add(gebeurtenisveldBuilder.BuildInkomstenBelasting());
            Velden.Add(straatbuilder.Naam(Veldnamen.KALVERSTRAAT));
        }

        /// <summary>
        /// Plaatst een nieuwe speler op bij aanvang van het spel.
        /// </summary>
        /// <param name="nieuweSpeler"></param>
        public void Plaats(Speler nieuweSpeler)
        {
            nieuweSpeler.Positie = Velden[0];
        }

        public Veld GeefVeld(string veldnaam)
        {
            return Velden.FindLast(item => item.Naam.Equals(veldnaam));
        }

        /// <summary>
        /// Geeft het nieuwe veld ten opzichte van de huidige positie en de worp. 
        /// </summary>
        /// <param name="Positie"></param>
        /// <param name="worp"></param>
        /// <returns></returns>
        public Veld GeefVeld(Veld huidigePositie, Worp worp)
        {
            return GeefVeld(huidigePositie, worp.Totaal());
            //int pos = Velden.IndexOf(huidigePositie);
            //int nieuwePos = pos + worp.Totaal();
            //if (nieuwePos >= Velden.Count)
            //{
            //    nieuwePos = nieuwePos - Velden.Count;
            //}
            //return Velden[nieuwePos];
        }

        public Veld GeefVeld(Veld huidigePositie, int aantalPosities)
        {
            int pos = Velden.IndexOf(huidigePositie);
            int nieuwePos = pos + aantalPosities;
            if (nieuwePos >= Velden.Count)
            {
                nieuwePos = nieuwePos - Velden.Count;
            }
            else if (nieuwePos < 0)
            {
                nieuwePos = Velden.Count + nieuwePos;
            }
            return Velden[nieuwePos];
        }
    }
}
