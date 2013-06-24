using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly.domein
{
    class Dobbelsteen
    {
        private Random dobbelsteen;

        public Dobbelsteen()
        {
            dobbelsteen = new Random(DateTime.Now.Millisecond);
        }

        public int Gooi()
        {
            return dobbelsteen.Next(1, 6);
        }
    }
}
