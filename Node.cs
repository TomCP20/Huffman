namespace Huffman;

public class Node
{
    public readonly int weight;

    public readonly char symbol;

    public readonly Node? lChild;
    public readonly Node? rChild;

    public Node(Node lChild, Node rChild)
    {
        weight = lChild.weight + rChild.weight;
        this.lChild = lChild;
        this.rChild = rChild;
    }

    public Node(char symbol, int weight)
    {
        this.symbol = symbol;
        this.weight = weight;
    }

    public Dictionary<char, List<bool>> generateEncodingTable()
    {
        Dictionary<char, List<bool>> encodingTable = new Dictionary<char, List<bool>>();
        DFS(encodingTable, new List<bool>());
        return encodingTable;
    }

    private void DFS(Dictionary<char, List<bool>> encodingTable, List<bool> code)
    {
        if (isLeaf())
        {
            encodingTable.Add(symbol, new List<bool>(code));
        }
        else
        {
            if (lChild != null)
            {
                code.Add(false);
                lChild.DFS(encodingTable, code);
                code.RemoveAt(code.Count - 1);
            }

            if (rChild != null)
            {
                code.Add(true);
                rChild.DFS(encodingTable, code);
                code.RemoveAt(code.Count - 1);
            }
        }
    }

    public bool isLeaf()
    {
        return lChild == null && rChild == null;
    }

}