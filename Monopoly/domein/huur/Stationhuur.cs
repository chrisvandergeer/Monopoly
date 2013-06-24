using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.velden;

namespace Monopoly.domein.huur
{
    public class Stationhuur : IHuurprijsBepaler
    {
        private static int[] HUURBEDRAGEN = new int[] { 0, 25, 50, 100, 200 };

        public int BepaalHuurprijs(IHypotheekveld veld)
        {
            Speler eigenaar = veld.Eigenaar;
            List<IHypotheekveld> velden = eigenaar.Bezittingen.Hypotheekvelden;
            int aantalStations = velden.Count(item => item.Naam.StartsWith("Station") && !item.Hypotheek.IsOnderHypotheek);
            return HUURBEDRAGEN[aantalStations];
        }
    }
}
