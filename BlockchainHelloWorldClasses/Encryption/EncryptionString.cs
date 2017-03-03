using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BlockchainHelloWorldClasses.Block.Encryption {
    public class EncryptionString:EncryptionBase {


        public string Encrypt(String s) {

            //convert string to byte[]
            byte[] b = ToByte(s);

            //convert byte[] to sha1
            byte[] sha = ByteToSha1(b);

            // convert sha1 to string
            String result = ShaToString(sha);

            return result;

        }

        /// <summary>
        /// String to byte:
        /// </summary>
        /// <param name="s">String to be converted to byte array</param>
        /// <returns>byte array</returns>
        private byte[] ToByte(String s) {
            return Encoding.UTF8.GetBytes(s);
        }


    }
}