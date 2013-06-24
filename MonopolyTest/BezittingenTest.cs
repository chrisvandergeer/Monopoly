using Monopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Monopoly.domein.velden;
using System.Collections.Generic;
using Monopoly.domein.huur;
using Monopoly.builders;
using Monopoly.domein.labels;

namespace MonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for BezittingenTest and is intended
    ///to contain all BezittingenTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BezittingenTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Bezittingen Constructor
        ///</summary>
        [TestMethod()]
        public void BezittingenConstructorTest()
        {
            Bezittingen bezittingen = new Bezittingen();
            Assert.AreEqual(1500, bezittingen.Kasgeld);
            Assert.IsNotNull(bezittingen.Hypotheekvelden);
            Assert.AreEqual(0, bezittingen.Hypotheekvelden.Count);
        }

        /// <summary>
        ///A test for AantalHypotheekvelden
        ///</summary>
        [TestMethod()]
        public void AantalHypotheekveldenTest()
        {
            Bezittingen bezittingen = createBezittingen();
            Assert.AreEqual(2, bezittingen.Hypotheekvelden.Count);
        }


        /// <summary>
        ///A test for AantalVeldenMetHypotheek
        ///</summary>
        [TestMethod()]
        public void AantalVeldenMetHypotheekTest()
        {
            Bezittingen bezittingen = createBezittingen();
            bool gelukt = bezittingen.Hypotheekvelden[0].Hypotheek.NeemHypotheek();
            Assert.IsTrue(gelukt);
            Assert.AreEqual(1, bezittingen.AantalVeldenMetHypotheek());

        }

        /// <summary>
        ///A test for Betaal
        ///</summary>
        [TestMethod()]
        public void BetaalTest()
        {
            Bezittingen bezittingen = createBezittingen();
            bool isGelukt = bezittingen.Betaal(1500);
            Assert.IsTrue(isGelukt);
            Assert.AreEqual(0, bezittingen.Kasgeld);
        }

        /// <summary>
        ///A test for Betaal
        ///</summary>
        [TestMethod()]
        public void BetaalTestNietVoldoendeGeld()
        {
            Bezittingen bezittingen = createBezittingen();
            bool isGelukt = bezittingen.Betaal(1501);
            Assert.IsFalse(isGelukt);
            Assert.AreEqual(1500, bezittingen.Kasgeld);
        }

        /// <summary>
        ///A test for Betaal
        ///</summary>
        [TestMethod()]
        public void BetaalAanAndereSpelerTest()
        {
            Speler spelerX = new Monopolyspel().VoegSpelerToe("Speler X");
            Bezittingen bezittingen = createBezittingen();
            bezittingen.Betaal(1500, spelerX);
            Assert.AreEqual(0, bezittingen.Kasgeld);
            Assert.AreEqual(3000, spelerX.Bezittingen.Kasgeld);
            
        }

        /// <summary>
        ///A test for GeefBebouwbareStraten
        ///</summary>
        [TestMethod()]
        public void GeefBebouwbareStratenTest()
        {
            Monopolyspel spel = new Monopolyspel();
            Speler spelerX = spel.VoegSpelerToe("Speler X");
            spelerX.Bezittingen.OntvangGeld(150000); // Speler heeft voldoende geld nodig om de test uit te kunnen voeren
            Bezittingen bezittingen = spelerX.Bezittingen;
            ((Straat)spel.Bord.GeefVeld(Veldnamen.KALVERSTRAAT)).Verkoop(spelerX);
            Assert.AreEqual(0, spelerX.Bezittingen.GeefBebouwbareStraten().Count);
            ((Straat)spel.Bord.GeefVeld(Veldnamen.LEIDSCHESTRAAT)).Verkoop(spelerX);
            List<Straat> bebouwbareStraten = bezittingen.GeefBebouwbareStraten();
            Assert.AreEqual(2, bebouwbareStraten.Count);
            Straat straat = bebouwbareStraten[0];
            // Een straat waarop een hypotheek rust is niet bebouwbaar
            straat.Hypotheek.NeemHypotheek();
            Assert.AreEqual(1, bezittingen.GeefBebouwbareStraten().Count);
            // Wanneer de hypotheek is afgelost is de straat weer bebouwbaar
            straat.Hypotheek.LosHypotheekAf();
            Assert.AreEqual(2, bezittingen.GeefBebouwbareStraten().Count);
            // Wanneer de straat volgebouwd is is deze niet meer bebouwbaar
            straat.Bebouw(); straat.Bebouw(); straat.Bebouw(); straat.Bebouw(); 
            Assert.AreEqual(1, bezittingen.GeefBebouwbareStraten().Count);
        }

        /// <summary>
        ///A test for GeefBebouwdeStraten
        ///</summary>
        [TestMethod()]
        public void GeefBebouwdeStratenTest()
        {
            Monopolyspel spel = new Monopolyspel();
            Speler spelerX = spel.VoegSpelerToe("Speler X");
            ((Straat)spel.Bord.GeefVeld(Veldnamen.KALVERSTRAAT)).Verkoop(spelerX);
            Assert.AreEqual(0, spelerX.Bezittingen.GeefBebouwbareStraten().Count);
            ((Straat)spel.Bord.GeefVeld(Veldnamen.LEIDSCHESTRAAT)).Verkoop(spelerX);
            Assert.AreEqual(2, spelerX.Bezittingen.GeefBebouwbareStraten().Count);
        }


        /// <summary>
        ///A test for OntvangGeld
        ///</summary>
        [TestMethod()]
        public void OntvangGeldTest()
        {
            Bezittingen bezittingen = createBezittingen();
            bezittingen.OntvangGeld(1);
            Assert.AreEqual(1501, bezittingen.Kasgeld);
        }

        /// <summary>
        ///A test for Straten
        ///</summary>
        [TestMethod()]
        public void StratenTest()
        {
            Bezittingen bezittingen = createBezittingen();
            Assert.AreEqual(1, bezittingen.Straten().Count);
        }


        private static Bezittingen createBezittingen()
        {
            Bezittingen bezittingen = new Bezittingen();
            Speler speler = new Speler("De speler", new Monopolyspel());
            Straat straat = new Straat("Xyzstraat", 100, new Straathuur(1, 2, 3, 4, 5, 6));
            straat.Verkoop(speler);
            bezittingen.Hypotheekvelden.Add(straat);
            Bedrijf bedrijf = new Bedrijf("Station", 1, new Stationhuur());
            bedrijf.Verkoop(speler);
            bezittingen.Hypotheekvelden.Add(bedrijf);
            return bezittingen;
        }
    }
}
