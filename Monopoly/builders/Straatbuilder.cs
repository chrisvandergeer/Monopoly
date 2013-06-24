using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein;
using Monopoly.domein.velden;
using Monopoly.domein.labels;

namespace Monopoly.builders
{
    public class Straatbuilder
    {
        private List<Straat> Straten { get; set; }

        public Straatbuilder()
        {
            Straten = new List<Straat>();
        }

        public Straatbuilder Build()
        {
            Straten.AddRange(BuildAmsterdam().Straten);
            Straten.AddRange(BuildArnhem().Straten);
            Straten.AddRange(BuildDenhaag().Straten);
            Straten.AddRange(BuildGroningen().Straten);
            Straten.AddRange(BuildHaarlem().Straten);
            Straten.AddRange(BuildOnsdorp().Straten);
            Straten.AddRange(BuildRotterdam().Straten);
            Straten.AddRange(BuildUtrecht().Straten);
            return this;
        }

        public Straat Naam(string straatnaam)
        {
            if (!Straten.Exists(s => s.Naam.Equals(straatnaam))) {
                throw new ApplicationException("Straat niet gevonden: " + straatnaam);
            }
            return Straten.First(s => s.Naam.Equals(straatnaam));
        }

        private Stad BuildAmsterdam()
        {
            Straat[] straten = new Straat[] {
                new Straat(Veldnamen.KALVERSTRAAT, 400, new Straathuur(50, 200, 600, 1400, 1700, 2000)),
                new Straat(Veldnamen.LEIDSCHESTRAAT, 350, new Straathuur(35, 175, 500, 1100, 1300, 1500))
            };
            return new Stad(Stadnamen.AMSTERDAM, straten);
        }

        private Stad BuildArnhem()
        {
            Straat[] straten = new Straat[] {
                new Straat(Veldnamen.STEENSTRAAT, 100, new Straathuur(6, 30, 90, 270, 400, 550)),
                new Straat(Veldnamen.KETELSTRAAT, 100, new Straathuur(6, 30, 90, 270, 400, 550)),
                new Straat(Veldnamen.VELPERPLEIN, 120, new Straathuur(6, 40, 120, 360, 450, 600))
            };
            return new Stad(Stadnamen.ARNHEM, straten);
        }

        private Stad BuildDenhaag()
        {
            Straat[] straten = new Straat[] {
                new Straat(Veldnamen.SPUI, 260, new Straathuur(22, 110, 330, 800, 975,1150)),
                new Straat(Veldnamen.LANGE_POTEN, 280, new Straathuur(24, 120, 360, 850, 1025, 1200)),
                new Straat(Veldnamen.PLEIN, 260, new Straathuur(22, 110, 330, 800, 975, 1150))
            };
            return new Stad(Stadnamen.DEN_HAAG, straten);
        }

        private Stad BuildGroningen()
        {
            Straat[] straten = new Straat[] {
                new Straat(Veldnamen.AKERKHOF, 180, new Straathuur(14, 70, 200, 550, 750, 950)),
                new Straat(Veldnamen.GROTE_MARKT, 180, new Straathuur(14, 70, 200, 550, 750, 950)),
                new Straat(Veldnamen.HEERESTRAAT, 200, new Straathuur(16, 80, 220, 600, 800, 1000))
            };
            return new Stad(Stadnamen.GRONINGEN, straten);
        }

        private Stad BuildHaarlem()
        {
            Straat[] straten = new Straat[] {
                new Straat(Veldnamen.BARTELJORISSTRAAT, 140, new Straathuur(10, 50, 150, 450, 625, 750)),
                new Straat(Veldnamen.ZIJLWEG, 140, new Straathuur(10, 50, 150, 450, 625, 750)),
                new Straat(Veldnamen.HOUTSTRAAT, 160, new Straathuur(12, 60, 180, 500, 700, 900))
            };
            return new Stad(Stadnamen.HAARLEM, straten);
        }

        private Stad BuildOnsdorp()
        {
            Straat[] straten = new Straat[] {
                new Straat(Veldnamen.DORPSSTRAAT, 60, new Straathuur(2, 10, 30, 90, 160, 250)),
                new Straat(Veldnamen.BRINK, 60, new Straathuur(4, 20, 60, 180, 320, 450))
            };
            return new Stad(Stadnamen.ONS_DORP, straten);
        }

        private Stad BuildRotterdam()
        {
            Straat[] straten = new Straat[] {
                new Straat(Veldnamen.HOFPLEIN, 300, new Straathuur(26, 130, 390, 900, 1100, 1275)),
                new Straat(Veldnamen.BLAAK, 300, new Straathuur(26, 130, 390, 900, 1100, 1275)),
                new Straat(Veldnamen.COOLSINGEL, 320, new Straathuur(28, 150, 450, 1000, 1200, 1400))
            };
            return new Stad(Stadnamen.ROTTERDAM, straten);
        }

        private Stad BuildUtrecht()
        {
            Straat[] straten = new Straat[] {
            new Straat(Veldnamen.NEUDE, 180, new Straathuur(14, 70, 200, 550, 750, 950)),
            new Straat(Veldnamen.BILTSTRAAT, 180, new Straathuur(14, 70, 200, 550, 750, 950)),
            new Straat(Veldnamen.VREEBURG, 200, new Straathuur(16, 80, 220, 600, 800, 1000))
            };
            return new Stad(Stadnamen.UTRECHT, straten);
        }

    }
}
