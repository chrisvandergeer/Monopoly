using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.velden;

namespace Monopoly.domein
{
    public class Stad
    {
        public string Naam { get; private set; }
        public List<Straat> Straten { get; private set; }

        public Stad(string stadnaam, params Straat[] straten)
        {
            Straten = new List<Straat>();
            foreach (var straat in straten)
            {
                straat.SetStad(this);
                Straten.Add(straat);
            }
        }

        /// <summary>
        /// Controleert of meegegeven speler alle straten behorend bij stad in bezit heeft.
        /// </summary>
        /// <param name="speler"></param>
        /// <returns></returns>
        public bool BezitStad(Speler speler)
        {
            return Straten.Count(straat => speler.Equals(straat.Eigenaar)) == Straten.Count;
        }

        public bool BezitHelft(Speler speler)
        {
            return Straten.Count(s => speler.Equals(s.Eigenaar)) > Straten.Count / 2;
        }

        public bool IsAllesVerkocht()
        {
            return Straten.Count(s => s.Eigenaar != null) == Straten.Count;
        }
    }
}
