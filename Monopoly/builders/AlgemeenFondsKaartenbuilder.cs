using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monopoly.domein;
using Monopoly.domein.gebeurtenissen;
using Monopoly.domein.labels;

namespace Monopoly.builders
{
    public class AlgemeenFondsKaartenbuilder
    {
        public GebeurtenisStapel build()
        {
            List<IGebeurtenis> kaarten = new List<IGebeurtenis>();
            kaarten.Add(new OntvangGeld(100).SetTekst("U erft ƒ 100"));
            kaarten.Add(new OntvangGeld(25).SetTekst("U ontvangt rente van 7% preferente aandelen ƒ 25"));
            kaarten.Add(new OntvangGeld(200).SetTekst("Een vergissing van de bank in uw voordeel, u ontvangt ƒ 200"));
            //_kaarten.Add(new GaTerugNaar(OnsDorpBuilder.Instance.OnsDorp.getStraatByName(OnsDorpBuilder.DORPSSTRAAT)));
            //_kaarten.Add(new GaNaarGevangenis());
            //// U bent jarig en ontvangt van iedere speler ƒ 10
            kaarten.Add(new OntvangGeld(10).SetTekst("U hebt de tweede prijs in een schoonheidswedstrijd gewonnen en ontvangt ƒ 10"));
            kaarten.Add(new BetaalGeld(50).SetTekst("Betaal uw doktersrekening ƒ 50"));
            //_kaarten.Add(new BetaalGeld(50, "Betaal uw verzekeringspremie ƒ 50"));
            //_kaarten.Add(new OntvangGeld(50, "Door verkoop van effecten ontvangt u ƒ 50"));
            //_kaarten.Add(new VerlaatDeGevangenis(_kaarten));
            //_kaarten.Add(new OntvangGeld(20, "Restitutie inkomstenbelasting, u ontvangt ƒ 20"));
            //_kaarten.Add(new OntvangGeld(100, "Lijfrente vervalt, u ontvangt ƒ 100"));
            //_kaarten.Add(new BetaalGeld(100, "Betaal het hospitaal ƒ 100"));
            //_kaarten.Add(new GaNaarGebeurtenis(Start.VELD_NAAM, "Ga verder naar 'Start'"));
            //// Betaal ƒ 10 boete of neem een Kanskaart
            return new GebeurtenisStapel(kaarten, "Algemeen Fonds");
        }
    }
}
