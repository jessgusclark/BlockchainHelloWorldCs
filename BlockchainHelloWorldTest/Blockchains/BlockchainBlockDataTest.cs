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

        [TestInitialize()]
        public void Initialize() {
            e = new EncryptionBlock();
            b1 = new BlockData(1);
            b2 = new BlockData(2);
        }

        [TestMethod]
        public void TestBaseBlockBlockChain() {
            b1.AddData("Hello World 1");
            b2.AddData("Hello World 2");

            b2.SetPreviousBlock(b1);

            Assert.AreEqual("{id:2,nonce:0,data:\"Hello World 2\",previous:{id:1,nonce:0,data:\"Hello World 1\",previous:null}}", b2.ToString());
        }


    }
}
