using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.velden;

namespace Monopoly.domein.akties
{
    public class Hypotheek
    {
        private IHypotheekveld HypotheekObject { get; set; }
        public bool IsOnderHypotheek { get; private set; }

        public Hypotheek(IHypotheekveld eigendom)
        {
            HypotheekObject = eigendom;
        }
        
        public bool NeemHypotheek()
        {
            Speler eigenaar = HypotheekObject.Eigenaar;
            if (IsOnderHypotheek)
                return false;
            eigenaar.Bezittingen.OntvangGeld(HypotheekObject.Koopprijs / 2);
            IsOnderHypotheek = true;
            return true;
        }

        public int HypotheekAflosbedrag()
        {
            Speler eigenaar = HypotheekObject.Eigenaar;
            int hypotheekBedrag = HypotheekObject.Koopprijs / 2;
            return hypotheekBedrag + (int)(hypotheekBedrag * 0.1);
        }

        public bool LosHypotheekAf()
        {
            if (IsOnderHypotheek)
            {
                Speler eigenaar = HypotheekObject.Eigenaar;
                int aflosBedrag = HypotheekAflosbedrag();
                if (eigenaar.Bezittingen.Betaal(aflosBedrag))
                {
                    IsOnderHypotheek = false;
                    return true;
                }
            }
            return false;
        }
    }
}
