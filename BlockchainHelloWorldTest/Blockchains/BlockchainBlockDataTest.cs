using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockchainHelloWorldClasses.Block.Encryption;
using BlockchainHelloWorldClasses.Block.Block;

namespace BlockchainHelloWorldTest.Blockchains {
    [TestClass]
    public class BlockchainBlockDataTest {


        EncryptionBlock e;
        BlockData b1;
        BlockData b2;

        String hash1;
        String hash2;

        [TestInitialize()]
        public void Initialize() {
            e = new EncryptionBlock();
            b1 = new BlockData(1);
            b2 = new BlockData(2);

            b1.SetData("Hello World 1");
            b2.SetData("Hello World 2");

            b2.SetPreviousBlock(b1);

            hash1 = b1.GetHash();
            hash2 = b2.GetHash();
        }

        [TestMethod]
        public void TestBaseBlockBlockChain() {

            String expected = "{id:2,nonce:0,hash:\"" + hash2 + "\",previousHash:\"" + hash1 + "\",mined:\"1/1/0001 12:00:00 AM\",data:\"Hello World 2\"},{id:1,nonce:0,hash:\"" + hash1 + "\",previousHash:\"\",mined:\"1/1/0001 12:00:00 AM\",data:\"Hello World 1\"}";

            Assert.AreEqual(expected, b2.BlockToString(true));

            Assert.IsFalse(b1.IsSigned() && b2.IsSigned());
        }


    }
}
