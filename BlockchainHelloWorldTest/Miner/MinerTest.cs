using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockchainHelloWorldClasses.Block.Miner;
using BlockchainHelloWorldClasses.Block;
using BlockchainHelloWorldClasses.Block.Encryption;

namespace BlockchainHelloWorldTest.Miner {
    [TestClass]
    public class MinerTest {

        BlockBase b1;
        MinerBase mb;

        [TestInitialize()]
        public void Initialize() {
            b1 = new BlockBase(1);
            mb = new MinerBase();
        }

        [TestMethod]
        public void TestMinerBlockBaseMine() {

            mb.SetDifficulty(1);

            mb.Mine(b1);

            int nonce = mb.GetBlockchain().GetNonce();

            // Assert the nonce:
            Assert.AreEqual(2, nonce);

            // Is the nonce set on the block?
            Assert.AreEqual(b1.GetNonce(), nonce);

            // Check the hash's starting 0:
            EncryptionBlock e = new EncryptionBlock();
            String hash = e.Encrypt(b1);
            //Assert.AreEqual("06c24c8fe5e39f038a3570e562fc279e37af97d3", hash);

        }

        [TestMethod]
        public void TestMinerBlockBaseMineAddBlock() {

            mb.SetDifficulty(1);

            mb.Mine(b1);
            Assert.AreEqual(1, mb.GetBlockchain().GetId());

            //mine again:
            mb.Mine(new BlockBase(2));
            Assert.AreEqual(2, mb.GetBlockchain().GetId());

            //mine again:
            mb.Mine(new BlockBase(3));
            Assert.AreEqual(3, mb.GetBlockchain().GetId());

        }


        [TestMethod]
        public void TestMinerBaseDifficulty() {

            mb.SetDifficulty(2);

            mb.Mine(b1);

            int nonce = mb.GetBlockchain().GetNonce();

            Assert.AreEqual(690, nonce);

            // Let's see the Hash:
            EncryptionBlock e = new EncryptionBlock();
            String hash = e.Encrypt(b1);
            //Assert.AreEqual("0086f15ccc3f3164004aeff5792c3e054d746d5a", hash);

        }

        [TestMethod]
        public void TestMinerMineDate() {
            mb.SetDifficulty(2);

            Assert.IsFalse(b1.IsSigned());

            mb.Mine(b1);
            Assert.AreNotEqual("1/1/0001 12:00:00 AM", b1.GetMinedDate().ToString());
            Assert.IsTrue(b1.IsSigned());
        }

    }
}
