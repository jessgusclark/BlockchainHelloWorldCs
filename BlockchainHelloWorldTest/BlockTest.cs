using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockchainHelloWorld;
using BlockchainHelloWorld.Encryption;

namespace BlockchainHelloWorldTest {
    [TestClass]
    public class BlockTest {

        private Block b1;
        //private Encryption e;

        [TestInitialize()]
        public void Initialize() {
            b1 = new Block();
            //e = new EncryptionString();
        }

        [TestMethod]
        public void TestBlock() {

            Assert.AreEqual(0, b1.GetId());

            b1.SetId(10);
            Assert.AreEqual(10, b1.GetId());

        }

        [TestMethod]
        public void TestPreviousGetId() {

            Block b2 = new Block();
            b2.SetId(2);

            b1.SetId(1);

            b2.SetPreviousBlock(b1);

            Assert.AreEqual(1, b2.GetPreviousBlock().GetId());
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestSetPreviosBlockSelf() {
            b1.SetPreviousBlock(b1);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestSetPreviosBlockNot() {
            Block b3 = new Block();
            b3.SetId(3);

            b1.SetPreviousBlock(b3);
        }


    }
}
