using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlockchainHelloWorldClasses.Block.Block {
    public class BlockData:BlockBase {

        private string Data;

        public BlockData(int i) : base(i) {}

        /// <summary>
        /// Setter
        /// </summary>
        public void SetData(string d) {
            if (IsSigned())
                throw new Exception("Block is signed and cannot be changed");

            Data = d;
        }

        /// <summary>
        /// Getter
        /// </summary>
        public string GetData() {
            return Data;
        }

        /// <summary>
        /// Override GetFormattedData();
        /// </summary>
        /// <returns>Data field</returns>
        protected override String GetFormattedData() {
            return "\"" + GetData() + "\"";
        }


    }
}