using BlockchainHelloWorldClasses.Block.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlockchainHelloWorldClasses.Block {
    public class BlockBase {

        protected int Id;
        protected int Nonce;
        protected String Hash;
        protected String PreviousHash;
        protected BlockBase PreviousBlock;

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
            PreviousHash = PreviousBlock.GetHash();
        }

        /// <summary>
        /// Getters
        /// </summary>
        public int GetId() {
            return Id;
        }

        public int GetNonce(){
            return Nonce;
        }

        public BlockBase GetPreviousBlock() {
            return PreviousBlock;
        }


        /// <summary>
        /// Setter
        /// </summary>
        /// <param name="i"></param>
        public void SetNonce(int i){
            Nonce = i;
        }



        /// <summary>
        /// Override for ToString()
        /// </summary>
        /// <returns></returns>
        public override String ToString() {

            // Genesis Block:
            if (PreviousBlock == null)
                return "{id:" + Id + ",nonce:" + Nonce + ",previous:null}";
            
            // Add Previous Block (BlockChain!):
            return "{id:" + Id + "," +
                    "nonce:" + Nonce + "," +
                    "hash:" + Hash + "," +
                    "previous:" + PreviousBlock.ToString() + 
                    "}";

        }

        /// <summary>
        /// Return the hashed value or compute hash if not set.
        /// Hash is saved to prevent StackOverflow when converting the object ToString()
        /// </summary>
        /// <returns>Computed Hash</returns>
        public String GetHash() {
            //prevents overflow?
            if (Hash != "")
                return Hash;

            EncryptionBlock e = new EncryptionBlock();
            Hash = e.Encrypt(this);

            return Hash;
        }

    }
}