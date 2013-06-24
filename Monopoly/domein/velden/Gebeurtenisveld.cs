using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.gebeurtenissen;

namespace Monopoly.domein.velden
{
    public class Gebeurtenisveld : Veld
    {
        private IGebeurtenis Gebeurtenis { get; set; }

        public Gebeurtenisveld(string naam, IGebeurtenis gebeurtenis)
            : base(naam)
        {
            Gebeurtenis = gebeurtenis;
        }

        public override IGebeurtenis BepaalGebeurtenis()
        {
            return Gebeurtenis;
        }
    }
}
