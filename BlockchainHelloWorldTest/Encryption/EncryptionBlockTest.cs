using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockchainHelloWorld.Block.Encryption;
using BlockchainHelloWorld.Block;

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

            BlockBase b = new BlockBase(1);

            String result = e.Encrypt(b);

            Assert.AreEqual("1c25f7a1c8bc785d70a77d6317aae5c678d5f02f", result);

        }


        [TestMethod]
        public void TestEncryptBlockNotEqual() {

            BlockBase b1 = new BlockBase(1);
            BlockBase b2 = new BlockBase(2);

            Assert.AreNotEqual(e.Encrypt(b1), e.Encrypt(b2));

        }


    }
}
