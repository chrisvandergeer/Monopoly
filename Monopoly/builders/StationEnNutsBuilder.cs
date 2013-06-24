using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.velden;
using Monopoly.domein;
using Monopoly.domein.labels;
using Monopoly.domein.huur;

namespace Monopoly.builders
{
    public class StationEnNutsBuilder 
    {
        private static int AANKOOPPRIJS = 200;

        public Bedrijf buildStationNoord()
        {
            return build(Veldnamen.STATION_NOORD);
        }

        public Bedrijf buildStationOost()
        {
            return build(Veldnamen.STATION_OOST);
        }

        public Bedrijf buildStationZuid()
        {
            return build(Veldnamen.STATION_ZUID);
        }

        public Bedrijf buildStationWest()
        {
            return build(Veldnamen.STATION_WEST);
        }

        private Bedrijf build(string stationsNaam)
        {
            return new Bedrijf(stationsNaam, AANKOOPPRIJS, new Stationhuur());
        }

        public Bedrijf buildNutsWaterleiding()
        {
            return new Bedrijf(Veldnamen.NUTS_WATERLEIDING, 150, new NutsbedrijfHuur());
        }

        public Bedrijf buildNutsElektriciteit()
        {
            return new Bedrijf(Veldnamen.NUTS_ELEKTRICITEIT, 150, new NutsbedrijfHuur());
        }
        
    }
}
