using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.velden;

namespace Monopoly.domein
{
    public class Bezittingen
    {
        public int Kasgeld { get; private set; }
        public List<IHypotheekveld> Hypotheekvelden { get; private set; }

        public Bezittingen()
        {
            Kasgeld = 1500;
            Hypotheekvelden = new List<IHypotheekveld>();
        }

        public List<Straat> Straten()
        {
            return Hypotheekvelden
                .FindAll(element => element is Straat)
                .ConvertAll(new Converter<IHypotheekveld, Straat>(IHypotheek2Straat));
        }

        public static Straat IHypotheek2Straat(IHypotheekveld veld)
        {
            return (Straat) veld;
        }

        public bool Betaal(int bedrag)
        {
            if (Kasgeld >= bedrag)
            {
                Kasgeld -= bedrag;
                return true;
            }
            return false;
        }

        public bool Betaal(int bedrag, Speler begunstigde)
        {
            if (Betaal(bedrag))
            {
                begunstigde.Bezittingen.OntvangGeld(bedrag);
                return true;
            }
            return false;
        }

        public void OntvangGeld(int bedrag)
        {
            Kasgeld += bedrag;
        }

        public List<Straat> GeefBebouwbareStraten()
        {
            return Straten().FindAll(straat => straat.KanBebouwdWordenMetHuis());
        }

        /// <returns>De som van het aantal velden in bezit</returns>
        public int AantalHypotheekvelden()
        {
            return Hypotheekvelden.Count;
        }

        /// <returns>De som van alle velden met een hypotheek</returns>
        public int AantalVeldenMetHypotheek()
        {
            int result = Hypotheekvelden.Count(item => item.Hypotheek.IsOnderHypotheek);
            return result;
        }

        /// <returns>true indien er bebouwde straten zijn</returns>
        public bool HeeftBebouwdeStraten()
        {
            return GeefBebouwdeStraten().Count > 0;

        }

        /// <returns>Lijst met bebouwde straten</returns>
        public List<Straat> GeefBebouwdeStraten()
        {
            return GeefBebouwbareStraten().FindAll(straat => straat.AantalHuizen > 0);
        }
    }
}
