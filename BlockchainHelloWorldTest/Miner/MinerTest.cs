using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockchainHelloWorld.Block.Miner;
using BlockchainHelloWorld.Block;
using BlockchainHelloWorld.Block.Encryption;

namespace BlockchainHelloWorldTest.Miner {
    [TestClass]
    public class MinerTest {

        BlockBase b1;
        MinerBase mb;

        [TestInitialize()]
        public void Initialize() {
            b1 = new BlockBase(1);
            mb = new MinerBase();
            mb.SetBlock(b1);
        }

        [TestMethod]
        public void TestMinerBlockBase() {

            Assert.AreEqual(b1, mb.GetBlock());

            Assert.AreEqual(
                b1.GetId(),
                mb.GetBlock().GetId()
                );

        }

        [TestMethod]
        public void TestMinerBlockBaseMine() {

            mb.SetDifficulty(1);

            int nonce = mb.Mine();

            // Assert the nonce:
            Assert.AreEqual(19, nonce);

            // Is the nonce set on the block?
            Assert.AreEqual(b1.GetNonce(), nonce);

            // Check the hash's starting 0:
            EncryptionBlock e = new EncryptionBlock();
            String hash = e.Encrypt(b1);
            Assert.AreEqual("06c24c8fe5e39f038a3570e562fc279e37af97d3", hash);

        }

        [TestMethod]
        public void TestMinerBaseDifficulty() {

            mb.SetDifficulty(2);
            int nonce = mb.Mine();

            Assert.AreEqual(90, nonce);

            // Let's see the Hash:
            EncryptionBlock e = new EncryptionBlock();
            String hash = e.Encrypt(b1);
            Assert.AreEqual("0086f15ccc3f3164004aeff5792c3e054d746d5a", hash);

        }

    }
}
