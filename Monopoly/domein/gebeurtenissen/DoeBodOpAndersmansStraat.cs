using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.velden;

namespace Monopoly.domein.gebeurtenissen
{
    public class DoeBodOpAndersmansStraat : Gebeurtenis
    {
        public DoeBodOpAndersmansStraat() : base(Gebeurtenisnamen.DOE_BOD_OPANDERMANSTRAAT) { }

        public override bool IsVerplicht()
        {
            return false;
        }

        public override bool IsUitvoerbaar(Speler speler)
        {
            int aantal = KandidaatStraten(speler).Count;
            return aantal > 0;
        }

        public override void Voeruit(Speler speler)
        {
            Straat teKopenStraat = KandidaatStraten(speler)[0].Stad.Straten.Find(s => !s.Eigenaar.Equals(speler));
            Gebeurtenisresult.Create(speler, "koopt*", teKopenStraat, "van", teKopenStraat.Eigenaar);
            teKopenStraat.Verkoop(speler);
        }

        private List<Straat> KandidaatStraten(Speler speler)
        {
            List<Straat> straten = speler.Bezittingen.Straten().FindAll(s => s.Stad.BezitHelft(speler));
            return straten.FindAll(s => s.Stad.IsAllesVerkocht());
        }
    }
}
