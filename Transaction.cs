using System.Security.Cryptography;
using System.Text;

namespace Blockchain;

public class Transaction
{
    public string Nonce { get; set; }
    public decimal Value { get; set; }
    public string To { get; set; }
    public string From { get; set; }

    public string Hash()
    {
        using (var sha256 = SHA256.Create())
        {
            var inputBytes = Encoding.UTF8.GetBytes($"{Nonce} {To} {From}");
            var outputBytes = sha256.ComputeHash(inputBytes);

            return Convert.ToBase64String(outputBytes);
        }
    }
}