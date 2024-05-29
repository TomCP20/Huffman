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
            if (pointer is InternalNode I)
            {
                if (bit)
                {
                    pointer = I.rChild;
                }
                else
                {
                    pointer = I.lChild;
                }
            }
            if (pointer is LeafNode l)
            {
                output.Append(l.symbol);
                pointer = tree;
            }

        }
        return output.ToString();
    }
}