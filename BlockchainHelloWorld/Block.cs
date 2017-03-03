using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlockchainHelloWorld {
    public class Block {

        private int id;
        private Block previous;


        /// <summary>
        /// Setters
        /// </summary>
        public void SetId(int i){
            id = i;
        }

        /// <summary>
        /// Getters
        /// </summary>
        public int GetId() {
            return id;
        }

    }
}