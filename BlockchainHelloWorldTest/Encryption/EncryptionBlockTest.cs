using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockchainHelloWorld.Encryption;
using BlockchainHelloWorld;

namespace BlockchainHelloWorldTest.Encryption {
    [TestClass]
    public class EncryptionBlockTest {

        private EncryptionBlock e;

        [TestInitialize()]
        public void Initialize() {
            e = new EncryptionBlock();
        }


        [TestMethod]
        public void TestEncryptBlock() {

            Block b = new Block(0);

            String result = e.Encrypt(b);

            Assert.AreEqual("45d34de26c1af1b73784a49ab1ddfc76940ca491", result);
          
        }
    }
}
