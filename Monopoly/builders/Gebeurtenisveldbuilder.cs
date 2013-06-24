using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein.velden;
using Monopoly.domein.labels;
using Monopoly.domein.gebeurtenissen;
using Monopoly.domein;

namespace Monopoly.builders
{
    public class Gebeurtenisveldbuilder
    {
        public Gebeurtenisveld BuildStart()
        {
            return new Gebeurtenisveld(
                Veldnamen.START, new OntvangGeld(400).SetTekst(GebeurtenisMelding.OP_START));
        }

        public Gebeurtenisveld BuildInkomstenBelasting()
        {
            return new Gebeurtenisveld(
                Veldnamen.INKOMSTENBELASTING, 
                new BetaalGeld(150).SetTekst(GebeurtenisMelding.INKOMSTENBELASTING));
        }

        public Gebeurtenisveld BuildAlgemeenFonds()
        {
            return new Gebeurtenisveld(
                Veldnamen.ALGEMEEN_FONDS, 
                new AlgemeenFondsKaartenbuilder().build());
        }
    }
}
