using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockchainHelloWorldClasses.Block.Encryption;
using BlockchainHelloWorldClasses.Block;
using BlockchainHelloWorldClasses.Block.Block;

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

            Assert.AreEqual("f6aefbd1d0e4fe63ce121c227ef6d80344763428", result);

        }


        [TestMethod]
        public void TestEncryptBlockNotEqual() {

            BlockBase b1 = new BlockBase(1);
            BlockBase b2 = new BlockBase(2);

            Assert.AreNotEqual(e.Encrypt(b1), e.Encrypt(b2));

        }

        [TestMethod]
        public void TestEncryptedBlockData() {

            BlockData b1 = new BlockData(1);

            String result = e.Encrypt(b1);

            // hash of BlockData(1):
            Assert.AreEqual("f6aefbd1d0e4fe63ce121c227ef6d80344763428", result);
        }

    }
}
