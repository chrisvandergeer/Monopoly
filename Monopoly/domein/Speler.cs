using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.velden;
using Monopoly.domein.gebeurtenissen;

namespace Monopoly.domein
{
    public class Speler
    {
        public Monopolyspel Spel                        { get; set; }
        public Veld Positie                            { get; set; }        
        public string Spelernaam                        { get; private set; }
        public Gebeurtenislijst BeurtGebeurtenissen     { get; set; }
        public Bezittingen Bezittingen                  { get; set; }

        public Speler(string spelersnaam, Monopolyspel spel)
        {
            Spel = spel;
            Spelernaam = spelersnaam;
            Bezittingen = new Bezittingen();
            BeurtGebeurtenissen = new Gebeurtenislijst(this);
        }

        public override bool Equals(object obj)
        {
            if (obj is Speler)
            {
                String naam = ((Speler)obj).Spelernaam;
                return naam == null ? Spelernaam == null : naam.Equals(Spelernaam);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Spelernaam == null ? 0 : Spelernaam.GetHashCode();
        }

        public override string ToString()
        {
            return Spelernaam == null ? "[null]" : Spelernaam;
        }

        public IGebeurtenis Verplaats(Worp worp)
        {
            Veld nieuwePositie = Spel.Bord.GeefVeld(Positie, worp);
            Positie = nieuwePositie;
            IGebeurtenis gebeurtenis = Positie.BepaalGebeurtenis();
            BeurtGebeurtenissen.VoegGebeurtenisToe(gebeurtenis);
            return gebeurtenis;
        }        

        public Gebeurtenislijst BepaalGebeurtenissenBijAanvangBeurt()
        {
            BeurtGebeurtenissen.MaakLeeg();
            BeurtGebeurtenissen.VoegGebeurtenisToe(new GooiDobbelstenen());
            BeurtGebeurtenissen.VoegGebeurtenisToe(new LosHypotheekAf());
            BeurtGebeurtenissen.VoegGebeurtenisToe(new KoopHuis());
            BeurtGebeurtenissen.VoegGebeurtenisToe(new NeemHypotheek());
            BeurtGebeurtenissen.VoegGebeurtenisToe(new EindeBeurt());
            BeurtGebeurtenissen.VoegGebeurtenisToe(new EindeSpel());
            return BeurtGebeurtenissen;
        }

        public void SpeelGebeurtenis(string gebeurtenisnaam)
        {
            BeurtGebeurtenissen.GeefGebeurtenis(gebeurtenisnaam).Voeruit(this);
        }

        public bool IsHuidigespeler()
        {
            return Spelernaam.Equals(Spel.HuidigeSpeler.Spelernaam);
        }
    }
}
