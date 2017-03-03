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

            Assert.AreEqual("{id:1,nonce:0,data:\"Hello World!\",previous:null}", b1.ToString());


        }

    }
}
