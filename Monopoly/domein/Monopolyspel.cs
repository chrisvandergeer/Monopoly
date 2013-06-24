using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.gebeurtenissen;

namespace Monopoly.domein
{
    public class Monopolyspel
    {
        public static readonly Speler BANK;

        public Spelbord Bord            { get; private set; }
        public List<Speler> Spelers     { get; private set; }
        public Speler HuidigeSpeler     { get; private set; }
        public bool SpelBeeindigd       { get; private set; }

        static Monopolyspel()
        {
            BANK = new Speler("de Bank", new Monopolyspel());
            BANK.Bezittingen.OntvangGeld(999999999);
        }

        public Monopolyspel()
        {
            Bord = new Spelbord();
            Spelers = new List<Speler>();
        }

        public Speler VoegSpelerToe(string spelersnaam)
        {
            Speler nieuweSpeler = new Speler(spelersnaam, this);
            if (Spelers.Contains(nieuweSpeler))
                throw new ApplicationException("Speler met deze naam doet al mee");
            Spelers.Add(nieuweSpeler);
            Bord.Plaats(nieuweSpeler);
            return nieuweSpeler;
        }

        public void Start()
        {
            int aantalSpelers = Spelers.Count;
            if (aantalSpelers < 2 || aantalSpelers > 8)
                throw new ApplicationException("Het aantal spelers moet tussen de 2 en 8 liggen");
            if (HuidigeSpeler != null)
                throw new ApplicationException("Het spel is al gestart");
            InitNieuweBeurt(0);
        }

        public void WisselBeurt()
        {
            int aantalSpelers = Spelers.Count;
            int idx = Spelers.IndexOf(HuidigeSpeler) + 1;
            idx = idx >= aantalSpelers ? 0 : idx;
            InitNieuweBeurt(idx);
        }

        private void InitNieuweBeurt(int idx)
        {
            HuidigeSpeler = Spelers[idx];
            HuidigeSpeler.BepaalGebeurtenissenBijAanvangBeurt();
        }

        public Gebeurtenisresult Beeindig()
        {
            SpelBeeindigd = true;
            Gebeurtenisresult result = Gebeurtenisresult.Create(HuidigeSpeler, "beeindigd het spel en heeft verloren");
            Spelers.ForEach(s => result.AppendResult(s, " - Kasgeld: " + s.Bezittingen.Kasgeld, ", Straten: " + s.Bezittingen.Hypotheekvelden.Count));
            return result;
        }
    }
}
