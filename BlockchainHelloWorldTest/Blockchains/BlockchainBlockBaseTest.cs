using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockchainHelloWorldClasses.Block;
using BlockchainHelloWorldClasses.Block.Encryption;

namespace BlockchainHelloWorldTest.Blockchains {
    /// <summary>
    /// Blockchain 1: 
    /// Nest one block inside another block.
    /// </summary>
    [TestClass]
    public class BlockchainBlockBaseTest {

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

            String expected = "{id:2,nonce:0,hash:\"1ff6c4000d29b9a7d9fba897e84cd67fa678595c\",previousHash:\"1c25f7a1c8bc785d70a77d6317aae5c678d5f02f\",previous:{id:1,nonce:0,previous:null}}";

            Assert.AreEqual(expected, b2.ToString());

        }

        [TestMethod]
        public void TestBaseBlockBlockChainHash() {

            b2.SetPreviousBlock(b1);

            Assert.AreEqual("65f56efcf2fb2f5836e17ad32f97151a8704f37d", e.Encrypt(b2));

        }

        [TestMethod]
        public void TestBaseBlockBlockChainGetHash() {

            b2.SetPreviousBlock(b1);

            Assert.AreEqual("1ff6c4000d29b9a7d9fba897e84cd67fa678595c", b2.GetHash());

            //Assert.AreEqual(b2.GetHash(), e.Encrypt(b2));

        }

    }
}
