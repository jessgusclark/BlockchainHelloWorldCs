using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace BlockchainHelloWorld.Block.Encryption {
    public class EncryptionBase {

        /// <summary>
        /// Convert byte to sha1
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        protected byte[] ByteToSha1(byte[] data) {

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
        protected String ShaToString(byte[] result) {
            var sb = new StringBuilder();
            foreach (byte b in result) {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }
    }
}