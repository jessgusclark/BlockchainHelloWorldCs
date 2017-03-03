using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace BlockchainHelloWorld {
    public class Encryption {


        public string Encrypt(String s) {

            //convert string to byte[]
            byte[] b = ToByte(s);

            //convert byte[] to sha1
            byte[] sha = ByteToSha1(b);

            // convert sha1 to string
            String result = ShaToString(sha);

            return result;

        }

        public string Encrypt(object o) {

            // convert object to byte[]
            byte[] b = ToByte(o);

            //convert byte[] to sha1
            byte[] sha = ByteToSha1(b);

            //convert to sha1 to string:
            String result = ShaToString(sha);

            return result;

        }


        /// <summary>
        /// 
        /// REFERENCE: 
        /// - http://stackoverflow.com/questions/1446547/how-to-convert-an-object-to-a-byte-array-in-c-sharp
        /// </summary>
        /// <param name="obj">Object to be converted to byte array</param>
        /// <returns>byte array</returns>
        private byte[] ToByte(Object obj) {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream()) {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// String to byte:
        /// </summary>
        /// <param name="s">String to be converted to byte array</param>
        /// <returns>byte array</returns>
        private byte[] ToByte(String s) {
            return Encoding.UTF8.GetBytes(s);
        }

        /// <summary>
        /// Convert byte to sha1
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private byte[] ByteToSha1(byte[] data) {

            // create sha instance:
            SHA1 sha = new SHA1CryptoServiceProvider();
            
            // return computedhash of s
            return sha.ComputeHash(data);
        }

        /// <summary>
        /// Converts byte[] to String of sha1
        /// </summary>
        /// <param name="result">Hash of the incoming string</param>
        /// <returns></returns>
        private String ShaToString(byte[] result) {
            var sb = new StringBuilder();
            foreach (byte b in result) {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }
    }
}