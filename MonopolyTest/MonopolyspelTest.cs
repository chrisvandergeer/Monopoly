using Monopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MonopolyTest
{   
    
    /// <summary>
    ///This is a test class for MonopolyspelTest and is intended
    ///to contain all MonopolyspelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MonopolyspelTest
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
        ///A test for WisselBeurt
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Monopoly.exe")]
        public void WisselBeurtTest()
        {
            Monopolyspel spel = new Monopolyspel();
            spel.VoegSpelerToe("Speler x");
            spel.VoegSpelerToe("Speler y");
            spel.VoegSpelerToe("Speler z");
            spel.Start();
            Assert.AreEqual("Speler x", spel.HuidigeSpeler.Spelernaam);
            spel.WisselBeurt();
            Assert.AreEqual("Speler y", spel.HuidigeSpeler.Spelernaam);
            spel.WisselBeurt();
            Assert.AreEqual("Speler z", spel.HuidigeSpeler.Spelernaam);
            spel.WisselBeurt();
            Assert.AreEqual("Speler x", spel.HuidigeSpeler.Spelernaam);
        }
    }
}
