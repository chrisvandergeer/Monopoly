using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.akties;
using Monopoly.domein.gebeurtenissen;

namespace Monopoly.domein.velden
{
    public class Hypotheekveld : Veld, IHypotheekveld
    {
        private IHuurprijsBepaler HuurprijsBepaler { get; set; }
        public Hypotheek Hypotheek { get; private set; }

        public int Koopprijs    { get; private set; }
        public Speler Eigenaar  { get; private set; }

        public Hypotheekveld(string naam, int koopprijs, IHuurprijsBepaler huurprijsBepaler)
            : base(naam)
        {
            Koopprijs = koopprijs;
            HuurprijsBepaler = huurprijsBepaler;
            Hypotheek = new Hypotheek(this);
        }

        public int BepaalHuurprijs()
        {
            return HuurprijsBepaler.BepaalHuurprijs(this);
        }

        public bool Verkoop(Speler koper)
        {
            if (koper.Bezittingen.Betaal(Koopprijs))
            {
                Eigenaar = koper;
                koper.Bezittingen.Hypotheekvelden.Add(this);
                return true;
            }
            return false;
        }

        public override IGebeurtenis BepaalGebeurtenis()
        {
            if (Eigenaar == null)
                return new KoopStraat(this);
            if (Eigenaar.IsHuidigespeler())
                return new Vrij(this + " is van " + Eigenaar);
            return new BetaalHuur(this);
        }
    }
}
