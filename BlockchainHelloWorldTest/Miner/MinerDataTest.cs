using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockchainHelloWorldClasses.Block.Miner;
using BlockchainHelloWorldClasses.Block.Block;

namespace BlockchainHelloWorldTest.Miner {
    [TestClass]
    public class MinerDataTest {
        BlockData b1;
        MinerData mb2;

        [TestInitialize()]
        public void Initialize() {
            b1 = new BlockData(1);
            mb2 = new MinerData();
        }

        [TestMethod]
        public void TestMineBlockWithData() {

            mb2.SetDifficulty(2);

            b1 = new BlockData(1);
            b1.SetData("Hello World!");

            mb2.Mine(b1);

            int nonce = b1.GetNonce();

            Assert.AreEqual(299, nonce);

            // Show 
            Assert.AreEqual("{id:1,nonce:299,data:\"Hello World!\",previous:{id:0,nonce:0,data:\"Hello Genesis Block!\",previous:null}}", mb2.GetBlockchain().ToString());
        }

        [TestMethod]
        public void TestGetGeniesBlockDataType() {

            mb2.SetDifficulty(2);

            b1 = new BlockData(1);
            b1.SetData("Hello World!");

            mb2.Mine(b1);

            // get type of Genesis block:
            Assert.IsInstanceOfType(mb2.GetBlockchain().GetPreviousBlock(), typeof(BlockData));

            //Assert.AreEqual("Hello Genesis Block!", mb2.GetBlockchain().GetPreviousBlock().GetData());
        }

        [TestMethod]
        public void TestMineBlockDataBlockchain() {

            MinerData mb2 = new MinerData();

            mb2.SetDifficulty(1);

            for (var i = 1; i <= 3; i++) {

                BlockData b = new BlockData(i);
                b.SetData("Hello World " + i + "!");

                mb2.Mine(b);

            }

            Assert.IsInstanceOfType(mb2.GetBlockchain(), typeof(BlockData));

            Assert.AreEqual(
                "{id:3,nonce:22,data:\"Hello World 3!\",previous:{id:2,nonce:20,data:\"Hello World 2!\",previous:{id:1,nonce:17,data:\"Hello World 1!\",previous:{id:0,nonce:0,data:\"Hello Genesis Block!\",previous:null}}}}",
                mb2.GetBlockchain().ToString());

        }


    }
}
