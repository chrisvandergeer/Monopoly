using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein;
using Monopoly.domein.gebeurtenissen;

namespace Monopoly.AI
{    

    public class AIDecider
    {
        private static List<string> DEFAULT_STRATEGY = new List<string>(new String[] { 
                Gebeurtenisnamen.LOS_HYPOTHEEK_AF,Gebeurtenisnamen.KOOP_STRAAT, Gebeurtenisnamen.KOOP_HUIS, 
                Gebeurtenisnamen.GOOI_DOBBELSTENEN, Gebeurtenisnamen.EINDE_BEURT, 
                Gebeurtenisnamen.BETAAL_HUUR, Gebeurtenisnamen.VERKOOP_HUIS, Gebeurtenisnamen.NEEM_HYPOTHEEK, 
                Gebeurtenisnamen.EINDE_SPEL
        });

        private Dictionary<String, IDecision> Decisions { get; set; }
        private IDecision DefaultDecision { get; set; }

        public AIDecider()
        {
            Decisions = new Dictionary<string, IDecision>();
            DefaultDecision = new DefaultDecision();
        }

        public void AddDecision(string gebeurtenisnaam, IDecision decision)
        {
            Decisions.Add(gebeurtenisnaam, decision);
        }

        public string Decide(Monopolyspel spel)
        {
            Speler huidigespeler = spel.HuidigeSpeler;
            string gebeurtenis = DEFAULT_STRATEGY.Find(g => IsUitvoerbaar(huidigespeler, g) && Decide(huidigespeler, g));
            return gebeurtenis;
        }

        private bool IsUitvoerbaar(Speler speler, string gebeurtenisnaam)
        {
            Gebeurtenislijst gebeurtenissen = speler.BeurtGebeurtenissen;
            if (gebeurtenissen.BevatGebeurtenis(gebeurtenisnaam))
            {
                IGebeurtenis gebeurtenis = gebeurtenissen.GeefGebeurtenis(gebeurtenisnaam);
                if (gebeurtenis.IsUitvoerbaar(speler))
                {
                    return true;
                }
            }
            return false;
        }

        private bool Decide(Speler speler, string gebeurtenisnaam)
        {
            IGebeurtenis gebeurtenis = speler.BeurtGebeurtenissen.GeefGebeurtenis(gebeurtenisnaam);
            return GetDecision(gebeurtenisnaam).decide(speler, gebeurtenis);
        }

        private IDecision GetDecision(string gebeurtenisnaam)
        {
            if (Decisions.ContainsKey(gebeurtenisnaam))
                return Decisions[gebeurtenisnaam];
            return DefaultDecision;
        }
    }
}
