using Monopoly.domein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Monopoly.domein.velden;
using Monopoly.domein.labels;

namespace MonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for SpelbordTest and is intended
    ///to contain all SpelbordTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SpelbordTest
    {

        /// <summary>
        ///A test for GeefVeld
        ///</summary>
        [TestMethod()]
        public void GeefVeldTestAchteruit()
        {
            Spelbord spelbord = new Spelbord();
            Veld start = spelbord.GeefVeld(Veldnamen.START);
            Veld veld = spelbord.GeefVeld(start, -1);
            Assert.AreEqual(Veldnamen.KALVERSTRAAT, veld.Naam);
        }

        /// <summary>
        ///A test for GeefVeld
        ///</summary>
        [TestMethod()]
        public void GeefVeldTestVooruit()
        {
            Spelbord spelbord = new Spelbord();
            Veld kalverstraat = spelbord.GeefVeld(Veldnamen.KALVERSTRAAT);
            Veld veld = spelbord.GeefVeld(kalverstraat, 1);
            Assert.AreEqual(Veldnamen.START, veld.Naam);
        }
    }
}
