namespace Huffman;

public class InternalNode : Node
{
    public readonly Node lChild;
    public readonly Node rChild;
    public InternalNode(Node lChild, Node rChild)
    {
        Weight = lChild.weight + rChild.weight;
        this.lChild = lChild;
        this.rChild = rChild;
    }

    public override void DFS(Dictionary<char, List<bool>> encodingTable, List<bool> code)
    {
        code.Add(false);
        lChild.DFS(encodingTable, code);
        code.RemoveAt(code.Count - 1);
        code.Add(true);
        rChild.DFS(encodingTable, code);
        code.RemoveAt(code.Count - 1);
    }
}