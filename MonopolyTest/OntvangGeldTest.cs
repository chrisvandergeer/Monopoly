using Monopoly.domein.gebeurtenissen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Monopoly.domein;

namespace MonopolyTest
{
    
    
    /// <summary>
    ///This is a test class for OntvangGeldTest and is intended
    ///to contain all OntvangGeldTest Unit Tests
    ///</summary>
    [TestClass()]
    public class OntvangGeldTest
    {
        /// <summary>
        ///A test for Voeruit
        ///</summary>
        [TestMethod()]
        public void VoeruitTest()
        {
            Bezittingen bezittingen = new Bezittingen();
            int kasgeld = bezittingen.Kasgeld;
            bezittingen.OntvangGeld(3);
            Assert.AreEqual(kasgeld + 3, bezittingen.Kasgeld);
        }
 
    }
}
