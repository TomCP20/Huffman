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
                pointer = pointer.rChild;
            }
            else
            {
                pointer = pointer.lChild;
            }
            if (pointer.lChild == null || pointer.rChild == null)
            {
                output.Append(pointer.symbol);
                pointer = tree;
            }

        }
        return output.ToString();
    }
}