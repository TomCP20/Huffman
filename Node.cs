namespace Huffman;

public abstract class Node
{
    protected int Weight;

    public Dictionary<char, List<bool>> generateEncodingTable()
    {
        Dictionary<char, List<bool>> encodingTable = new Dictionary<char, List<bool>>();
        DFS(encodingTable, new List<bool>());
        return encodingTable;
    }

    public int weight
    {
        get {return Weight;}
    }

    public abstract void DFS(Dictionary<char, List<bool>> encodingTable, List<bool> code);

}