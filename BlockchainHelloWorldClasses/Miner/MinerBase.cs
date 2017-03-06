using BlockchainHelloWorldClasses.Block.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlockchainHelloWorldClasses.Block.Miner {
    public class MinerBase {

        protected BlockBase Blockchain;
        private int Difficulty;

        /// <summary>
        /// Constructor. Create the Genesis block
        /// </summary>
        public MinerBase() {
            Blockchain = new BlockBase(0);
        }


        /// <summary>
        /// Getters
        /// </summary>
        /// <returns></returns>
        public BlockBase GetBlockchain() {
            return Blockchain;
        }

        /// <summary>
        /// Setters
        /// </summary>
        public void SetDifficulty(int i) {
            Difficulty = i;
        }


        /// <summary>
        /// Mine a block by trying a range of numbers from starting to ending with the miner's difficulty. 
        /// </summary>
        /// <param name="starting"></param>
        /// <param name="ending"></param>
        /// <returns>Returns nonce that solved the block</returns>
        public void Mine(BlockBase b, int starting = 0, int ending = 1000000) {

            if (Difficulty == 0)
                throw new Exception("Difficulty level has not been set.");

            EncryptionBlock e = new EncryptionBlock();

            for (int i = starting; i <= 1000000; i++) {
                
                //Set the nonce on the block:
                b.SetNonce(i);

                // if hash found:
                if (CompareHashAgainstDifficulty( b.GetHash() )) {
                    //attach the previous blocks to this block:
                    b.SetPreviousBlock(Blockchain);

                    //set mined date/time:
                    b.SetBlockMined(DateTime.Now);

                    //set this block as the current blockchain:
                    Blockchain = b;

                    //return something:
                    return;

                }
                    
            }

            // no result found:
            b.SetNonce(0);
            throw new Exception("No result found between [" + starting + "]-[" + ending + "] with a difficulty of [" + Difficulty + "]");

        }


        /// <summary>
        /// Check the hash against the difficulty. Right now the difficulty level is done with leading zeros
        /// 1 = 0, 2 = 00, 3 = 000, etc. 
        /// @todo: make this a bit more sophisticated
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        protected bool CompareHashAgainstDifficulty(String hash) {

            string stringDifficulty = "";
            for (int i = 0; i < Difficulty; i++) {
                stringDifficulty += "0";
            }

            if (hash.StartsWith(stringDifficulty))
                return true;

            return false;
        }

    }
}