namespace Blockchain;

public class Blockchain
{
    private const decimal GAS_LIMIT = 400000;
    private const decimal GAS_USED = 400000;
    public List<Block> Chain { get; set; }

    private void AddGenBlock()
    {
        Chain.Add(new(
            DateTime.Now,
            "0",
            0,
            GAS_LIMIT,
            GAS_USED,
            new List<Transaction>()
        ));
    }

    public void AddBlock(List<Transaction> transactions)
    {
        var previousBlock = Chain.Last();
        var newBlock = new Block(DateTime.Now, previousBlock.Hash, previousBlock.Nonce + 1, GAS_LIMIT, GAS_USED,
            transactions);
        Chain.Add(newBlock);
    }
}