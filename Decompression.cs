using System.Text;

namespace Huffman;

static class Decompression
{
    public static string Decompress(List<bool> compressed, Node tree)
    {
        StringBuilder output = new StringBuilder();
        Node pointer = tree;
        foreach (bool bit in compressed)
        {
            if (bit)
            {
                if (pointer.rChild != null)
                {
                    pointer = pointer.rChild;
                }
            }
            else
            {
                if (pointer.lChild != null)
                {
                    pointer = pointer.lChild;
                }
            }
            if (pointer.isLeaf())
            {
                output.Append(pointer.symbol);
                pointer = tree;
            }

        }
        return output.ToString();
    }
}