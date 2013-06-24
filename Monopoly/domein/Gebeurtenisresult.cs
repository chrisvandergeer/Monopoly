using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.domein
{
    public class Gebeurtenisresult
    {
        public bool IsUitgevoerd    { get; private set; }
        public string ResultTekst   { get; private set; }

        public void SetUitgevoerd(params object[] tekst)
        {
            IsUitgevoerd = true;
            ResultTekst = BuildTekst(tekst);
        }

        public void AppendResult(params object[] tekst)
        {
            ResultTekst = new StringBuilder().AppendLine(ResultTekst).Append(BuildTekst(tekst)).ToString();
        }

        internal void SetNietUitgevoerd(params object[] tekst)
        {
            ResultTekst = BuildTekst(tekst);
        }

        private string BuildTekst(object[] tekst)
        {
            StringBuilder builder = new StringBuilder();
            foreach (object o in tekst)
                builder.Append(o).Append(" ");
            return builder.ToString();
        }

        public override string ToString()
        {
            return ResultTekst;
        }


        public static Gebeurtenisresult Create(params object[] tekst)
        {
            Gebeurtenisresult result = new Gebeurtenisresult();
            result.ResultTekst = result.BuildTekst(tekst);
            return result;
        }

    }
}
