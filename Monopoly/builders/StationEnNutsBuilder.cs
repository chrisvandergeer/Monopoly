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

        public Hypotheekveld buildStationNoord()
        {
            return build(Veldnamen.STATION_NOORD);
        }

        public Hypotheekveld buildStationOost()
        {
            return build(Veldnamen.STATION_OOST);
        }

        public Hypotheekveld buildStationZuid()
        {
            return build(Veldnamen.STATION_ZUID);
        }

        public Hypotheekveld buildStationWest()
        {
            return build(Veldnamen.STATION_WEST);
        }

        private Hypotheekveld build(string stationsNaam)
        {
            return new Hypotheekveld(stationsNaam, AANKOOPPRIJS, new Stationhuur());
        }

        public Hypotheekveld buildNutsWaterleiding()
        {
            return new Hypotheekveld(Veldnamen.NUTS_WATERLEIDING, 150, new NutsbedrijfHuur());
        }

        public Hypotheekveld buildNutsElektriciteit()
        {
            return new Hypotheekveld(Veldnamen.NUTS_ELEKTRICITEIT, 150, new NutsbedrijfHuur());
        }
        
    }
}
