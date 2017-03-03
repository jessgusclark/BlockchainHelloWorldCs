using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;
using System.Text;
using BlockchainHelloWorld;

namespace BlockchainHelloWorldTest {
    [TestClass]
    public class EncryptionTest {

        private Encryption e;

        [TestInitialize()]
        public void Initialize() {
            e = new Encryption();
        }
        
        /// <summary>
        /// Basic SHA1 script in procedural format;
        ///   REFERENCES:
        /// - https://msdn.microsoft.com/en-us/library/system.security.cryptography.sha1(v=vs.110).aspx
        /// - https://gist.github.com/kristopherjohnson/3021045
        /// </summary>
        [TestMethod]
        public void TestBasicCrypto() {

            //byte[] data = new byte[256];
            byte[] data = Encoding.UTF8.GetBytes("Hello World");
            byte[] result;

            SHA1 sha = new SHA1CryptoServiceProvider();
            // This is one implementation of the abstract class SHA1.
            result = sha.ComputeHash(data);

            // convert the System.Byte[] to string:
            var sb = new StringBuilder();
            foreach (byte b in result) {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }

            //Assert:
            Assert.AreEqual("0a4d55a8d778e5022fab701977c5d840bbc486d0", sb.ToString());

        }


        [TestMethod]
        public void TestEncryptString() {

            
            String result = e.Encrypt("Hello World");

            Assert.AreEqual("0a4d55a8d778e5022fab701977c5d840bbc486d0", result );
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
