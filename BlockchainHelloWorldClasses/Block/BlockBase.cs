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
        protected DateTime BlockMined;

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
        
            //recaculate hash 
            GetHash();
            
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

        public DateTime GetMinedDate() {
            return BlockMined;
        }

        public bool IsSigned() {
            if (Nonce == 0)
                return false;

            return true;
        }


        /// <summary>
        /// Setter
        /// </summary>
        /// <param name="i"></param>
        public void SetNonce(int i){
            Nonce = i;
            GetHash();
        }

        public void SetBlockMined(DateTime d) {
            BlockMined = d;
            GetHash();
        }


        public String BlockToString(Boolean chain = false) {

            GetHash();

            String block = "{id:" + Id + "," +
                    "nonce:" + Nonce + "," +
                    "hash:\"" + Hash + "\"," +
                    "previousHash:\"" + PreviousHash + "\"," + 
                    "mined:\"" + BlockMined + "\"," +
                    "data:" + GetData() +
                    "}";

            if (chain)
                block += "," + PreviousBlock.BlockToString();

            return block;
        }



        /// <summary>
        /// Override for ToString() and is used to create the Hash. As a result, the 
        /// hash is not part of this method. To get the full ToString() with the hash
        /// uses BlockToString();
        /// </summary>
        /// <returns></returns>
        public override String ToString() {

            //Previous Hash:
            if (PreviousBlock != null)
                PreviousBlock.GetHash();

            // Add Previous Block (BlockChain!):
            String block = "{id:" + Id + "," +
                    "nonce:" + Nonce + "," +
                    "previousHash:\"" + PreviousHash + "\"," +
                    "mined:\"" + BlockMined + "\"," +
                    "data:" + GetData() +
                    "}";
            return block;

        }

        /// <summary>
        /// Return the hashed value or compute hash if not set.
        /// Hash is saved to prevent StackOverflow when converting the object ToString()
        /// </summary>
        /// <returns>Computed Hash</returns>
        public String GetHash() {
            //prevents overflow?
            //if (Hash != null)
            //    return Hash;

            //calculate previous block if not null (loop):
            if (PreviousBlock != null)
                PreviousBlock.GetHash();

            EncryptionBlock e = new EncryptionBlock();
            Hash = e.Encrypt(this);

            return Hash;
        }

        /// <summary>
        /// Will be overwrited by inherited classes
        /// </summary>
        /// <returns>null</returns>
        private String GetData(){
            return "\"\"";
        }

    }
}