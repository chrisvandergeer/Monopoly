using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.velden;

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
            bool b = speler.Bezittingen.HeeftBebouwdeStraten();
            return b;
        }

        public override void Voeruit(Speler speler)
        {
            List<Straat> bebouwdeStraten = speler.Bezittingen.GeefBebouwdeStraten();
            Straat bebouwdeStraat = bebouwdeStraten[0];
            bebouwdeStraat.VerkoopHuis();
            Gebeurtenisresult result = Gebeurtenisresult.Create(speler, "verkoopt zijn huis op", bebouwdeStraat);
            speler.BeurtGebeurtenissen.VoegResultToe(result);
        }
    }
}
