using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockchainHelloWorld.Block.Encryption;

namespace BlockchainHelloWorldTest.Encryption {
    [TestClass]
    public class EncryptionObjectTest {

        private EncryptionObject e;

        [TestInitialize()]
        public void Initialize() {
            e = new EncryptionObject();
        }

        [TestMethod]
        public void TestEncryptObject() {

            Object o = new Object();
            String result = e.Encrypt(o);

            Assert.AreEqual("39a848a5acbbcb47de857bb3815bf59b9506e123", result);

        }

        [TestMethod]
        public void TestEncryptTwoObjects() {

            Object o = new Object();
            Object o2 = new Object();

            String result1 = e.Encrypt(o);
            String result2 = e.Encrypt(o2);

            // not equal becuase they are different objects locally:
            Assert.AreNotEqual(o, o2);


            // should be the same since the object is converted first to a string:
            String s1 = o.ToString();
            String s2 = o2.ToString();

            Assert.AreEqual(e.Encrypt(o), e.Encrypt(o2));


            // The same because they are idential objects when converted to sha1:
            Assert.AreEqual(result1, result2);


        }
    }
}
