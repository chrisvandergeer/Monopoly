using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.velden;

namespace Monopoly.domein.gebeurtenissen
{
    public class VerplaatsSpeler : Gebeurtenis
    {
        private int AantalPosities { get; set; }
        private bool OntvangGeenStartgeld { get; set; }

        private VerplaatsSpeler(string gebeurtenistekst, int aantalPosities) : base(gebeurtenistekst) { }

        public static VerplaatsSpeler CreateVerplaatsVooruit(string gebeurtenistekst, int aantalPosities)
        {
            return new VerplaatsSpeler(gebeurtenistekst, aantalPosities);
        }

        public static VerplaatsSpeler CreateVerplaatsAchteruit(string gebeurtenistekst, int aantalPosities)
        {
            VerplaatsSpeler gebeurtenis = new VerplaatsSpeler(gebeurtenistekst, aantalPosities * -1);
            gebeurtenis.OntvangGeenStartgeld = true;
            return gebeurtenis;
        }

        public static VerplaatsSpeler CreateVerplaatsVooruitGeenStartgeld(string gebeurtenistekst, int aantalPosities)
        {
            VerplaatsSpeler gebeurtenis = new VerplaatsSpeler(gebeurtenistekst, aantalPosities);
            gebeurtenis.OntvangGeenStartgeld = true;
            return gebeurtenis;
        }

        public override bool IsVerplicht()
        {
            return true;
        }

        public override bool IsUitvoerbaar(Speler speler)
        {
            return true;
        }

        public override void Voeruit(Speler speler)
        {
            Veld huidigePositie = speler.Positie;
            Veld nieuwePositie = speler.Spel.Bord.GeefVeld(huidigePositie, AantalPosities);
            SetResult(speler.BeurtGebeurtenissen, Naam);
        }

    }
}
