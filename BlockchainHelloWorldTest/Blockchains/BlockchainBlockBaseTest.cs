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

        String b1Hash;
        String b2Hash;

        [TestInitialize()]
        public void Initialize() {
            e = new EncryptionBlock();
            b1 = new BlockBase(1);
            b2 = new BlockBase(2);

            b2.SetPreviousBlock(b1);

            b2Hash = "2ba28a1a777f623f9f76da46170b1b900e222bc2";
            b1Hash = "f6aefbd1d0e4fe63ce121c227ef6d80344763428";
        }


        /// <summary>
        /// Blockchain of BlockBase
        /// </summary>

        [TestMethod]
        public void TestBaseBlockBlockChainHash() {

            Assert.AreEqual(b2Hash, e.Encrypt(b2));

            Assert.AreEqual(b2Hash, b2.GetHash());
        }


        [TestMethod]
        public void TestBaseBlockBlockChain() {

            String expected = "{id:2,nonce:0,hash:\"" + b2Hash + "\",previousHash:\"" + b1Hash + "\",mined:\"1/1/0001 12:00:00 AM\",data:\"\"}";

            Assert.AreEqual(expected, b2.BlockToString());

        }

        [TestMethod]
        public void TestBaseBlockToString() {

            string singleBlock = b2.BlockToString(false);

            string expected = "{id:2,nonce:0,hash:\"" + b2Hash + "\",previousHash:\"" + b1Hash + "\",mined:\"1/1/0001 12:00:00 AM\",data:\"\"}";

            Assert.AreEqual(expected, singleBlock);

        }


        /// <summary>
        /// {
	    ///    id: 2,
	    ///        nonce: 0,
	    ///        hash: "",
	    ///        previousHash: "",
        ///        mined: "",
	    ///        data: ""
        ///    }, {
	    ///        id: 1,
	    ///        nonce: 0,
	    ///        hash: "",
        ///        mined: "",
	    ///        previousHash: "",
	    ///        data: ""
        ///    }
        /// </summary>
        [TestMethod]
        public void TestBaseBlockchainToString() {

            string singleBlock = b2.BlockToString(true);

            string expected = "{id:2,nonce:0,hash:\"" + b2Hash + "\",previousHash:\"" + b1Hash + "\",mined:\"1/1/0001 12:00:00 AM\",data:\"\"},{id:1,nonce:0,hash:\"" + b1Hash + "\",previousHash:\"\",mined:\"1/1/0001 12:00:00 AM\",data:\"\"}";

            Assert.AreEqual(expected, singleBlock);
        }

    }
}
