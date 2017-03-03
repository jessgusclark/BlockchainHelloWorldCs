using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace BlockchainHelloWorld.Encryption {
    public class EncryptionObject:EncryptionBase {

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

    }
}