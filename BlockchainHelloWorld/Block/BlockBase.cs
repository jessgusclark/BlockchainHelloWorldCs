using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlockchainHelloWorld.Block {
    public class BlockBase {

        private int Id;
        private BlockBase PreviousBlock;

        public BlockBase(int i) {
            Id = i;
        }


        /// <summary>
        /// Setters
        /// </summary>
        public void SetPreviousBlock(BlockBase b) {
            if ((b.GetId() + 1) != Id)
                throw new Exception("Id must be one less than current block!");

            PreviousBlock = b;
        }

        /// <summary>
        /// Getters
        /// </summary>
        public int GetId() {
            return Id;
        }

        public BlockBase GetPreviousBlock() {
            return PreviousBlock;
        }


        /// <summary>
        /// Override for ToString()
        /// </summary>
        /// <returns></returns>
        public String ToString() {

            return "{id:" + Id + "}";

        }

    }
}