using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockchainHelloWorld.Block.Encryption;

namespace BlockchainHelloWorldTest.Encryption {
    [TestClass]
    public class EncryptionStringTest {


        private EncryptionString e;

        [TestInitialize()]
        public void Initialize() {
            e = new EncryptionString();
        }

        [TestMethod]
        public void TestEncryptString() {

            String result = e.Encrypt("Hello World");

            Assert.AreEqual("0a4d55a8d778e5022fab701977c5d840bbc486d0", result);
        }


    }
}
