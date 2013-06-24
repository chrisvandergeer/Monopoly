using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.velden;
using Monopoly.domein.gebeurtenissen;
using Monopoly.domein.labels;

namespace Monopoly.domein.huur
{
    public class NutsbedrijfHuur : IHuurprijsBepaler
    {
        private static int[] MULTIPLIER = new int[] { 0, 4, 10 };

        public int BepaalHuurprijs(IHypotheekveld veld)
        {
            Speler eigenaar = veld.Eigenaar;
            Speler huidigeSpeler = eigenaar.Spel.HuidigeSpeler;
            Gebeurtenislijst gebeurtenissenHuidigeSpeler = huidigeSpeler.BeurtGebeurtenissen;
            GooiDobbelstenen gebeurtenis = (GooiDobbelstenen)gebeurtenissenHuidigeSpeler.GeefGebeurtenis(Gebeurtenisnamen.GOOI_DOBBELSTENEN);
            Worp laatsteWorp = gebeurtenis.LaatsteWorp();
            int aantalNutsbedrijvenInBezit = eigenaar.Bezittingen.Hypotheekvelden.Count(
                item => item.Naam.Equals(Veldnamen.NUTS_ELEKTRICITEIT) || item.Naam.Equals(Veldnamen.NUTS_WATERLEIDING)); 
            return laatsteWorp.Totaal() * MULTIPLIER[aantalNutsbedrijvenInBezit];
        }
    }
}
