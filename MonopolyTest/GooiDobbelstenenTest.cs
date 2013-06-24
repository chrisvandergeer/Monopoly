using Monopoly.domein.gebeurtenissen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Monopoly.domein;

namespace MonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for GooiDobbelstenenTest and is intended
    ///to contain all GooiDobbelstenenTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GooiDobbelstenenTest
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

        /// <summary>
        ///A test for Voeruit
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Monopoly.exe")]
        public void VoeruitTest()
        {
            Monopolyspel spel = new Monopolyspel();
            spel.VoegSpelerToe("Speler x");
            spel.VoegSpelerToe("Speler y");
            spel.Start();
            IGebeurtenis gebeurtenis = new GooiDobbelstenen();
            gebeurtenis.Voeruit(spel.HuidigeSpeler);
            Assert.IsTrue(spel.HuidigeSpeler.BeurtGebeurtenissen.Result.Exists(r => r.ResultTekst.Contains("gegooit en staat nu op")));
        }
    }
}
