using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockchainHelloWorldClasses.Block;
using BlockchainHelloWorldClasses.Block.Encryption;
using BlockchainHelloWorldClasses.Block.Miner;

namespace BlockchainHelloWorldTest.Blockchains {
    /// <summary>
    /// Blockchain 1: 
    /// Nest one block inside another block.
    /// </summary>
    [TestClass]
    public class BlockchainBlockBaseTest {

        BlockBase b1;
        BlockBase b2;

        String b1Hash;
        String b2Hash;

        MinerBase mb;

        [TestInitialize()]
        public void Initialize() {
            b1 = new BlockBase(1);
            b2 = new BlockBase(2);

            mb = new MinerBase();
            mb.SetDifficulty(1);

        }


        /// <summary>
        /// Blockchain of BlockBase
        /// </summary>


        [TestMethod]
        public void TestBaseBlockBlockChain() {

            mb.Mine(b1);
            mb.Mine(b2);

            Assert.AreEqual(b2.GetPreviousHash(), b1.GetHash());
            Assert.AreEqual(b1, b2.GetPreviousBlock());

            Assert.IsTrue(b1.IsSigned() && b2.IsSigned());

            Assert.AreNotEqual(0, b1.GetNonce());
            Assert.AreNotEqual(0, b2.GetNonce());

        }

        /// <summary>
        /// This test is for the structure not for the elements within the structure
        /// </summary>
        [TestMethod]
        public void TestBaseBlockToStringStructure() {

            mb.Mine(b1);
            mb.Mine(b2);

            string singleBlock = b2.BlockToString(false);

            string expected = "{id:2,nonce:" + mb.GetNonce() + ",hash:\"" + b2.GetHash() + "\",previousHash:\"" + b1.GetHash() + "\",mined:\"" + DateTime.Now + "\",data:\"\"}";

            Assert.AreEqual(expected, singleBlock);

        }

    }
}
