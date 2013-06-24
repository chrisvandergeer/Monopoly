using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.domein.gebeurtenissen
{
    public class GebeurtenisStapel : Gebeurtenis
    {
        private List<IGebeurtenis> Kaartstapel;

        public GebeurtenisStapel(List<IGebeurtenis> gebeurtenissen, string naam) : base(naam)
        {
            Kaartstapel = gebeurtenissen;
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
            IGebeurtenis kaart = Kaartstapel[0];
            Kaartstapel.RemoveAt(0);
            Kaartstapel.Add(kaart);
            if (kaart.IsUitvoerbaar(speler))
            {
                kaart.Voeruit(speler);
            }
            else
            {
                speler.BeurtGebeurtenissen.VoegGebeurtenisToe(this);
            }
        }
    }
}
