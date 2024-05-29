namespace Huffman;

static class Compression
{
    public static (List<bool>, Node) Compress(string text)
    {
        Dictionary<char, int> freq = GetFrequency(text);
        PriorityQueue<Node, int> queue = InitialiseQueue(freq);
        Node head = GetTree(queue);

        Dictionary<char, List<bool>> encodingTable = head.generateEncodingTable();

        List<bool> result = text.Select(c => encodingTable[c]).SelectMany(x => x).ToList();

        return (result, head);
    }



    private static Node GetTree(PriorityQueue<Node, int> queue)
    {
        while (queue.Count > 1)
        {
            Node a = queue.Dequeue();
            Node b = queue.Dequeue();
            Node c = new InternalNode(a, b);
            queue.Enqueue(c, c.weight);
        }
        Node head = queue.Dequeue();
        return head;
    }

    private static PriorityQueue<Node, int> InitialiseQueue(Dictionary<char, int> freq)
    {
        PriorityQueue<Node, int> queue = new PriorityQueue<Node, int>();
        foreach (KeyValuePair<char, int> entry in freq)
        {
            queue.Enqueue(new LeafNode(entry.Key, entry.Value), entry.Value);
        }
        return queue;
    }

    private static Dictionary<char, int> GetFrequency(string text)
    {
        Dictionary<char, int> freq = new Dictionary<char, int>();
        foreach (char c in text)
        {
            if (freq.ContainsKey(c))
            {
                freq[c] += 1;
            }
            else
            {
                freq.Add(c, 1);
            }
        }
        return freq;
    }
}