using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockchainHelloWorld;
using BlockchainHelloWorld.Encryption;

namespace BlockchainHelloWorldTest {
    [TestClass]
    public class BlockTest {

        private Block b1;

        [TestInitialize()]
        public void Initialize() {
            b1 = new Block(1);
        }

        [TestMethod]
        public void TestBlock() {

            Assert.AreEqual(1, b1.GetId());

        }

        [TestMethod]
        public void TestPreviousGetId() {

            Block b2 = new Block(2);

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
            Block b3 = new Block(3);

            b1.SetPreviousBlock(b3);
        }


    }
}
