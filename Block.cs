using System.Security.Cryptography;
using System.Text;

namespace Blockchain;

public class Block
{
    public DateTime TimeStamp { get; set; }
    public string PrevHash { get; set; }
    public string Hash { get; set; }
    public int Nonce { get; set; }
    public decimal GasLimit { get; set; }
    public decimal GasUsed { get; set; }
    public MerkleTree MerkleRoot { get; set; }


    public Block(DateTime timeStamp, string prevHash, int nonce,decimal  gasLimit, decimal gasUsed, List<Transaction> transactions)
    {
        TimeStamp = timeStamp;
        PrevHash = prevHash;
        Nonce = nonce;
        GasLimit = gasLimit;
        GasUsed = gasUsed;
        MerkleRoot = new MerkleTree();
        MerkleRoot.ComputeMerkleRoot(transactions.Select(h => h.Hash()).ToList());
        Hash = ComputeHash();
    }
    
    public string ComputeHash()
    {
        using (var sha256 = SHA256.Create())
        {
            var inputBytes = Encoding.UTF8.GetBytes($"{Nonce} - {TimeStamp} - {PrevHash} - {MerkleRoot}");
            var outputBytes = sha256.ComputeHash(inputBytes);

            return Convert.ToBase64String(outputBytes);
        }
    }
    
}