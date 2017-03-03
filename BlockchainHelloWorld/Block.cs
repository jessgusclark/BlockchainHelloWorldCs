using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlockchainHelloWorld {
    public class Block {

        private int Id;
        private Block PreviousBlock;
        private int p;

        public Block(int i) {
            Id = i;
        }


        /// <summary>
        /// Setters
        /// </summary>
        public void SetPreviousBlock(Block b) {
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

        public Block GetPreviousBlock() {
            return PreviousBlock;
        }

    }
}