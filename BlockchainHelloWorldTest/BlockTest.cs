using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockchainHelloWorld;
using BlockchainHelloWorld.Encryption;

namespace BlockchainHelloWorldTest {
    [TestClass]
    public class BlockTest {

        private Block b;
        //private Encryption e;

        [TestInitialize()]
        public void Initialize() {
            b = new Block();
            //e = new EncryptionString();
        }

        [TestMethod]
        public void TestBlock() {

            Assert.AreEqual(0, b.GetId());

            b.SetId(10);
            Assert.AreEqual(10, b.GetId());

        }

    }
}
