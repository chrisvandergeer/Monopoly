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
                Gebeurtenisnamen.LOS_HYPOTHEEK_AF,
                Gebeurtenisnamen.KOOP_STRAAT, Gebeurtenisnamen.KOOP_HUIS, 
                Gebeurtenisnamen.GOOI_DOBBELSTENEN, Gebeurtenisnamen.EINDE_BEURT, 
                Gebeurtenisnamen.BETAAL_HUUR, Gebeurtenisnamen.NEEM_HYPOTHEEK, Gebeurtenisnamen.EINDE_SPEL
        });

        public string Decide(Monopolyspel spel)
        {
            string gebeurtenis = DEFAULT_STRATEGY.Find(g => IsUitvoerbaar(spel, g));
            return gebeurtenis;
        }

        private bool IsHypotheekNemenEenOptie(Monopolyspel spel)
        {
            return spel.HuidigeSpeler.BeurtGebeurtenissen.BevatGebeurtenis(Gebeurtenisnamen.NEEM_HYPOTHEEK);
        }

        private bool IsUitvoerbaar(Monopolyspel spel, string gebeurtenisnaam)
        {
            Speler speler = spel.HuidigeSpeler;
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
    }
}
