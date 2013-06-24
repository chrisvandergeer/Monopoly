using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.gebeurtenissen;

namespace Monopoly.domein
{
    public class Gebeurtenislijst
    {
        public List<IGebeurtenis> Gebeurtenissen { get; private set; }
        public List<Gebeurtenisresult> Result { get; private set; }
        private Speler Speler { get; set; }

        public Gebeurtenislijst(Speler speler) : this(speler, new List<IGebeurtenis>()) { }

        private Gebeurtenislijst(Speler speler, List<IGebeurtenis> list)
        {
            Speler = speler;
            Gebeurtenissen = list;
            Result = new List<Gebeurtenisresult>();
        }

        public string UitgevoerdeGebeurtenissenToString()
        {
            StringBuilder builder = new StringBuilder();
            Result.ForEach(result => builder.AppendLine(result.ResultTekst));
            Result.Clear();
            return builder.ToString();
        }

        public string UitTeVoerenGebeurtenissenToString()
        {
            StringBuilder builder = new StringBuilder();
            List<IGebeurtenis> nietUitgevoerd = Gebeurtenissen.FindAll(g => g.IsUitvoerbaar(Speler));
            nietUitgevoerd.ForEach(g => builder.AppendLine("* " + g.Naam));
            return builder.ToString();
        }

        public void VoegGebeurtenisToe(IGebeurtenis gebeurtenis)
        {
            if (!BevatGebeurtenis(gebeurtenis.Naam))
                Gebeurtenissen.Add(gebeurtenis);
        }

        public bool BevatGebeurtenis(string naam)
        {
            return Gebeurtenissen.Exists(g => g.Naam.Equals(naam));
        }

        public IGebeurtenis GeefGebeurtenis(string naam)
        {
            return Gebeurtenissen.Find(g => g.Naam.Equals(naam));
        }

        public IGebeurtenis GeefGebeurtenis(int pos) 
        {
            return Gebeurtenissen[pos];
        }

        public void VerwijderNogUitTeVoerenGebeurtenissen()
        {
            Gebeurtenissen.Clear();
        }

        public bool BevatNogUitTeVoerenGebeurtenissen()
        {
            return Gebeurtenissen.Count > 0;
        }

        public bool BevatNogUitTeVoerenVerplichteGebeurtenissen()
        {
            return Gebeurtenissen.Exists(g => g.IsVerplicht());
        }

        public bool BevatUitgevoerdeGebeurtenissen()
        {
            return Result.Count > 0;
        }

        public void MaakLeeg()
        {
            Gebeurtenissen.Clear();
        }

        public int AantalVerplichtUitTeVoerenGebeurtenissen()
        {
            return Gebeurtenissen.Count(gebeurtenis => gebeurtenis.IsVerplicht());
        }

        public void VoegResultToe(Gebeurtenisresult result)
        {
            Result.Add(result);
        }


        public bool VerwijderGebeurtenis(IGebeurtenis gebeurtenis)
        {
            return Gebeurtenissen.Remove(gebeurtenis);
        }

        public IGebeurtenis VindEerste(List<string> gebeurtenissen)
        {
            foreach (string naam in gebeurtenissen)
            {
                if (Gebeurtenissen.Exists(g => g.Naam.Equals(naam))) {
                    return GeefGebeurtenis(naam);
                }
            }
            return null;
        }
    }
}
