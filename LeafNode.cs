namespace Huffman;

public class LeafNode : Node
{
    public readonly char symbol;
    public LeafNode(char symbol, int weight)
    {
        this.symbol = symbol;
        Weight = weight;

    }

    public override void DFS(Dictionary<char, List<bool>> encodingTable, List<bool> code)
    {
        encodingTable.Add(symbol, new List<bool>(code));
    }
}