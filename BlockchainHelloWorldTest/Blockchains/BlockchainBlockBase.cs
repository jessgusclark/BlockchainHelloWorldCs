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
            Assert.AreEqual("{id:2,nonce:0,previous:{id:1,nonce:0,previous:null}}", b2.ToString());

        }

        [TestMethod]
        public void TestBaseBlockBlockChainHash() {

            b2.SetPreviousBlock(b1);

            Assert.AreEqual("18134bdb6ef6923116f6e85422fa4cd1a2f92d95", e.Encrypt(b2));

        }

    }
}
