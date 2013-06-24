using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.velden;

namespace Monopoly.domein.gebeurtenissen
{
    class KoopHuis : Gebeurtenis
    {
        public KoopHuis() : base(Gebeurtenisnamen.KOOP_HUIS) { }

        public override bool IsVerplicht()
        {
            return false;
        }

        private Straat GeefKandidaatstraat(Speler speler)
        {
            List<Straat> bebouwbareStraten = speler.Bezittingen.GeefBebouwbareStraten();
            if (bebouwbareStraten.Count == 0)
            {
                return null;
            }
            bebouwbareStraten.Sort((x, y) => x.PrijsVoorEenHuis.CompareTo(y.PrijsVoorEenHuis));
            return bebouwbareStraten[0];
            
        }

        public override bool IsUitvoerbaar(Speler speler)
        {
            Straat straat = GeefKandidaatstraat(speler);
            if (speler.BeurtGebeurtenissen.BevatNogUitTeVoerenVerplichteGebeurtenissen() || straat == null)
                return false;
            return speler.Bezittingen.Kasgeld >= straat.PrijsVoorEenHuis;
        }

        public override void Voeruit(Speler speler)
        {
            Straat straat = GeefKandidaatstraat(speler);
            if (straat != null)
            {
                straat.Bebouw();
                Gebeurtenisresult result = Gebeurtenisresult.Create(speler, "plaatst een huis op", straat);
                speler.BeurtGebeurtenissen.VoegResultToe(result);
            }
        }


    }
}
