using System.Security.Cryptography;
using System.Text;

namespace Blockchain;

public class MerkleTree
{
    public string ComputeMerkleRoot(List<string> hashes)
    {
        if (hashes.Count == 0)
        {
            throw new ArgumentException("hash can not be empty");
        }

        while (hashes.Count > 1)
        {
            List<string> newHashes = new();

            for (int i = 0; i < hashes.Count; i += 2)
            {
                if (i + 1 < hashes.Count)
                {
                    newHashes.Add(Hash(hashes[i] + hashes[i + 1]));
                }
                else
                {
                    newHashes.Add(hashes[i]);
                }

                hashes = newHashes;
            }
        }

        return hashes[0];
    }

    public string Hash(string input)
    {
        using (var sha256 = SHA256.Create())
        {
            var inputBytes = Encoding.UTF8.GetBytes(input);
            var outputBytes = sha256.ComputeHash(inputBytes);

            return Convert.ToBase64String(outputBytes);
        }
    }
}