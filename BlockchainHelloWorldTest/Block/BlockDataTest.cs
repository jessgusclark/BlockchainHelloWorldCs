using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockchainHelloWorldClasses.Block.Block;

namespace BlockchainHelloWorldTest.Block {
    [TestClass]
    public class BlockDataTest {

        private BlockData b1;

        [TestInitialize()]
        public void Initialize() {
            b1 = new BlockData(1);
        }

        
        [TestMethod]
        public void TestParentConstructor() {
            Assert.AreEqual(1, b1.GetId());
        }

        [TestMethod]
        public void TestAddDataToBlock() {

            String str = "Hello World!";
            b1.SetData(str);

            Assert.AreEqual(str, b1.GetData());


        }

        [TestMethod]
        public void TestAddDataToString() {

            String str = "Hello World!";
            b1.SetData(str);

            Assert.AreEqual("{id:1,nonce:0,hash:\"ea9bac830f9dab6a4bd9b53b23c097cb3eb217d1\",previousHash:\"\",mined:\"1/1/0001 12:00:00 AM\",data:\"Hello World!\"}", b1.BlockToString());


        }

    }
}
