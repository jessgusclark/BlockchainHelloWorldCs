using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockchainHelloWorldClasses.Block;
using BlockchainHelloWorldClasses.Block.Encryption;

namespace BlockchainHelloWorldTest.Block {
    [TestClass]
    public class BlockTest {

        private BlockBase b1;

        [TestInitialize()]
        public void Initialize() {
            b1 = new BlockBase(1);
        }

        [TestMethod]
        public void TestBlock() {

            Assert.AreEqual(1, b1.GetId());

        }

        [TestMethod]
        public void TestBlockToString() {

            String result = b1.ToString();

            Assert.AreEqual("{id:1,nonce:0,previousHash:\"\",mined:\"1/1/0001 12:00:00 AM\",data:\"\"}", result);

        }

        [TestMethod]
        public void TestPreviousGetId() {

            BlockBase b2 = new BlockBase(2);

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
            BlockBase b3 = new BlockBase(3);

            b1.SetPreviousBlock(b3);
        }


    }
}
