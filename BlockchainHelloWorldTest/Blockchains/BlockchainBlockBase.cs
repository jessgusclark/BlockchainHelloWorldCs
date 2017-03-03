using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockchainHelloWorld.Block;
using BlockchainHelloWorld.Block.Encryption;

namespace BlockchainHelloWorldTest.Blockchains {
    [TestClass]
    public class BlockchainBlockBase {

        EncryptionBlock e;
        BlockBase b1;
        BlockBase b2;

        [TestInitialize()]
        public void Initialize() {
            e = new EncryptionBlock();
            b1 = new BlockBase(1);
            b2 = new BlockBase(2);
        }


        /// <summary>
        /// Blockchain of BlockBase
        /// </summary>
        [TestMethod]
        public void TestBaseBlockBlockChain() {

            b2.SetPreviousBlock(b1);
            Assert.AreEqual("{id:2,previous: {id:1,previous:null}}", b2.ToString());

        }

        [TestMethod]
        public void TestBaseBlockBlockChainHash() {

            b2.SetPreviousBlock(b1);

            Assert.AreEqual("116e318c7a12a34ccbde5c0f6f94ed9cbd16dedf", e.Encrypt(b2));

        }

    }
}
