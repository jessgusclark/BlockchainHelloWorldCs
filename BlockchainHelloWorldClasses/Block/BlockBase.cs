using BlockchainHelloWorldClasses.Block.Encryption;
using BlockchainHelloWorldClasses.Block.Miner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlockchainHelloWorldClasses.Block {
    public class BlockBase {

        protected int Id;
        private int Nonce;
        private Boolean Signed;
        protected String Hash;
        protected String PreviousHash;
        protected DateTime DateMined;

        protected BlockBase PreviousBlock;

        public BlockBase(int i) {
            Id = i;
            Signed = false;
        }

        /// <summary>
        /// DEPRECATED!
        /// </summary>
        /*public void SetPreviousBlock(BlockBase b) {
            if ((b.GetId() + 1) != Id)
                throw new Exception("Id must be one less than current block!");

            PreviousBlock = b;
            PreviousHash = PreviousBlock.GetHash();
        
            //recaculate hash 
            GetHash();
            
        }*/

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
            return DateMined;
        }

        public bool IsSigned() {
            return Signed;
        }

        public String GetHash() {
            return Hash;
        }

        public String GetPreviousHash() {
            return PreviousHash;
        }

        /// <summary>
        /// Used to test a nonce but does not set it. To set the nonce, use
        /// Sign(Miner);
        /// </summary>
        /// <param name="i"></param>
        /// <returns>Returns Hash</returns>
        public String TryNonce(int i) {
            return CalculateHash(i);
        }



        /// <summary>
        /// Sign Block
        /// </summary>
        /// <param name="miner"></param>
        public void Sign(MinerBase miner) {
            DateMined = DateTime.Now;
            Nonce = miner.GetNonce();
            PreviousHash = miner.GetBlockchain().GetHash();
            PreviousBlock = miner.GetBlockchain();
            
            //only place these should be set:
            Hash = CalculateHash(miner.GetNonce());
            Signed = true;
        }


        public String BlockToString(Boolean chain = false) {

            if (!Signed)
                throw new Exception("Block is not signed, BlockToString() cannot be executed");

            //build block:
            String block = "{id:" + Id + "," +
                    "nonce:" + Nonce + "," +
                    "hash:\"" + Hash + "\"," +
                    "previousHash:\"" + PreviousHash + "\"," + 
                    "mined:\"" + DateMined + "\"," +
                    "data:" + GetFormattedData() +
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
            return "Block " + Id;
        }


        /// <summary>
        /// Calculate the hash of the object given a nonce of i. Then compare against the miner's
        /// difficulty level to see if it can be signed with the nonce.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private String CalculateHash(int i) {

            String block = "{id:" + Id + "," +
                    "nonce:" + i + "," +
                    "previousHash:\"" + PreviousHash + "\"," +
                    "mined:\"" + DateMined + "\"," +
                    "data:" + GetFormattedData() +
                    "}";

            EncryptionString e = new EncryptionString();
            return e.Encrypt(block);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="miner">Hash with the given Nonce</param>
        /// <returns></returns>
        public String AcceptMiner(MinerBase miner) {
            return CalculateHash(miner.GetNonce());
        }


        /// <summary>
        /// Will be overwrited by inherited classes
        /// </summary>
        /// <returns>null</returns>
        protected virtual String GetFormattedData() {
            return "\"\"";
        }

    }
}