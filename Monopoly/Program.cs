using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein;
using Monopoly.domein.gebeurtenissen;
using Monopoly.AI;
using Monopoly.domein.velden;
using Monopoly.domein.labels;

namespace Monopoly
{
    class Program
    {
        private AIDecider aiDecider = new AIDecider();
        private SpelController controller = new SpelController();

        static void Main(string[] args)
        {
            new Program().run();
        }

        private void run()
        {
            AddDecisions();
            Monopolyspel spel = CreateGame();
            controller.StartSpel();
            int i = 0;
            Console.WriteLine("<pre>");
            while (!spel.SpelBeeindigd)
            {
                SpeelSpelersRonde(spel);
                PrintUitgevoerdEnUitTeVoerenGebeurtenissen(spel);
                controller.EindeBeurt();
                if (++i % spel.Spelers.Count == 0)
                {
                    PrintTussenstand(spel);
                }
            }
            Console.WriteLine("Einde spel");
            PrintTussenstand(spel);
            PrintEindstand(spel);
            Console.WriteLine("Aantal gespeelde rondes: " + i / spel.Spelers.Count);
            Console.WriteLine("</pre>");
        }

        private Monopolyspel CreateGame()
        {
            Monopolyspel spel = controller.MaakSpel();
            controller.VoegSpelerToe("Chris");
            controller.VoegSpelerToe("Roel");
            controller.VoegSpelerToe("Piet");
            return spel;
        }

        private void AddDecisions()
        {
            aiDecider.AddDecision(Gebeurtenisnamen.KOOP_HUIS, new KoopHuisDecision());
            aiDecider.AddDecision(Gebeurtenisnamen.DOE_BOD_OPANDERMANSTRAAT, new DoeBodOpAndermansStraatDecision());
        }
        
        private void SpeelSpelersRonde(Monopolyspel spel)
        {
            Console.WriteLine(Gebeurtenisresult.Create(spel.HuidigeSpeler, "is aan de beurt").ResultTekst);
            while (spel.HuidigeSpeler.BeurtGebeurtenissen.BevatNogUitTeVoerenGebeurtenissen())
            {
                string gebeurtenisnaam = aiDecider.Decide(spel);
                controller.SpeelGebeurtenis(gebeurtenisnaam);
            }
        }

        private void PrintUitgevoerdEnUitTeVoerenGebeurtenissen(Monopolyspel spel)
        {
            PrintUitgevoerdEnUitTeVoerenGebeurtenissen(spel.HuidigeSpeler.BeurtGebeurtenissen);
        }

        private void PrintUitgevoerdEnUitTeVoerenGebeurtenissen(Gebeurtenislijst gebeurtenissen)
        {
            if (gebeurtenissen.BevatUitgevoerdeGebeurtenissen())
                PrintUitgevoerdeGebeurtenissen(gebeurtenissen);
            if (gebeurtenissen.BevatNogUitTeVoerenGebeurtenissen())
                PrintUitTeVoerenGebeurtenissen(gebeurtenissen);
        }

        private void PrintUitgevoerdeGebeurtenissen(Gebeurtenislijst gebeurtenissen)
        {
            Console.WriteLine("Uitgevoerde gebeurtenissen:");
            Console.WriteLine(gebeurtenissen.UitgevoerdeGebeurtenissenToString());
        }

        private void PrintUitTeVoerenGebeurtenissen(Gebeurtenislijst gebeurtenissen)
        {
            Console.WriteLine("Uit te voeren gebeurtenissen:");
            Console.WriteLine(gebeurtenissen.UitTeVoerenGebeurtenissenToString());
        }

        private void PrintTussenstand(Monopolyspel spel)
        {
            Console.WriteLine("============================    Stand    ========================================");
            foreach (Speler speler in spel.Spelers)
            {
                Console.WriteLine(Gebeurtenisresult.Create("Bezittingen van", speler).ResultTekst);
                Bezittingen b = speler.Bezittingen;
                Console.WriteLine(Gebeurtenisresult.Create("Kasgeld", b.Kasgeld).ResultTekst);
                Console.WriteLine(Gebeurtenisresult.Create("Straten", b.AantalHypotheekvelden(), "waarvan", b.AantalVeldenMetHypotheek(), "met hypotheek").ResultTekst);
                Console.WriteLine();
            }
            Console.WriteLine("=======================================================================================");
        }

        private void PrintEindstand(Monopolyspel spel)
        {
            Console.WriteLine("============================     EINDSTAND     ========================================");
            foreach (Veld veld in spel.Bord.Velden)
            {
                if (veld is IHypotheekveld)
                {
                    IHypotheekveld hveld = (IHypotheekveld)veld;
                    int aantalHuizen = veld is Straat ? ((Straat)veld).AantalHuizen : 0;
                    Console.WriteLine(Gebeurtenisresult.Create(hveld, hveld.Eigenaar, hveld.Hypotheek.IsOnderHypotheek, aantalHuizen).ResultTekst);
                }
            }
            Console.WriteLine("=======================================================================================");
        }
    }
}
