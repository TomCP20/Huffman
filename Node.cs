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


}