using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlockchainHelloWorldClasses.Block.Block {
    public class BlockData:BlockBase {

        private string Data;
        new protected BlockData PreviousBlock;

        public BlockData(int i) : base(i) {}

        /// <summary>
        /// Setter
        /// </summary>
        public void SetData(string d) {
            Data = d;
        }

        public void SetPreviousBlock(BlockData b) {
            if ((b.GetId() + 1) != Id)
                throw new Exception("Id must be one less than current block!");

            PreviousBlock = b;
        }

        /// <summary>
        /// Getter
        /// </summary>
        public string GetData() {
            return Data;
        }

        public BlockData GetPreviousBlock() {
            return PreviousBlock;
        }

        /// <summary>
        /// ToString() includes data field
        /// </summary>
        /// <returns>Single Block or Blockchain if it is not Genesis block.</returns>
        public override string ToString() {

            // Genesis Block:
            String previousString = "null";

            // If not Genesis Block:
            if (PreviousBlock != null)
                previousString = PreviousBlock.ToString();

            // Add Previous Block (BlockChain!):
            return "{id:" + Id + "," +
                    "nonce:" + Nonce + "," +
                    "data:\"" + Data + "\"," +
                    "previous:" + previousString.ToString() +
                    "}";

        }

    }
}