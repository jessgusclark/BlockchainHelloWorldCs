using BlockchainHelloWorldClasses.Block.Block;
using BlockchainHelloWorldClasses.Block.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlockchainHelloWorldClasses.Block.Miner {
    public class MinerData:MinerBase {

        new protected BlockData Blockchain;

        /// <summary>
        /// Constructor. Create the Genesis block
        /// </summary>
        public MinerData() {
            Blockchain = new BlockData(0);
            Blockchain.SetData("Hello Genesis Block!");
        }

        new public BlockData GetBlockchain() {
            return Blockchain;
        }

        
    }
}