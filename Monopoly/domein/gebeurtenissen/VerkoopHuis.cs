using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.domein.gebeurtenissen
{
    public class VerkoopHuis : Gebeurtenis
    {
        public VerkoopHuis() : base(Gebeurtenisnamen.VERKOOP_HUIS) { }

        public override bool IsVerplicht()
        {
            return false;
        }

        public override bool IsUitvoerbaar(Speler speler)
        {
            throw new NotImplementedException();
        }

        public override void Voeruit(Speler speler)
        {
            throw new NotImplementedException();
        }
    }
}
