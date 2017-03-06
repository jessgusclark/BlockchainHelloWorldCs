using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockchainHelloWorldClasses.Block;
using BlockchainHelloWorldClasses.Block.Encryption;
using BlockchainHelloWorldClasses.Block.Miner;

namespace BlockchainHelloWorldTest.Block {
    [TestClass]
    public class BlockTest {

        BlockBase b1;
        MinerBase miner;
        String hash;

        [TestInitialize()]
        public void Initialize() {
            b1 = new BlockBase(1);

            miner = new MinerBase();
            miner.SetDifficulty(1);
            miner.Mine(b1);

            hash = b1.GetHash();
        }

        [TestMethod]
        public void TestBlock() {

            Assert.AreEqual(1, b1.GetId());

        }

        [TestMethod]
        public void TestBlockToString() {

            String result = b1.BlockToString();
            String expected = "{id:1,nonce:2,hash:\"" + hash + "\",previousHash:\"\",mined:\"" + DateTime.Now + "\",data:\"\"}";
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void TestPreviousGetId() {

            BlockBase b2 = new BlockBase(2);
            miner.Mine(b2);

            Assert.AreEqual(1, b2.GetPreviousBlock().GetId());
        }


        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestSetPreviosBlockNot() {
            BlockBase b3 = new BlockBase(3);

            miner.Mine(b3);

        }


    }
}
