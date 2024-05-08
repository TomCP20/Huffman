namespace Huffman;

static class Compression
{
    public static (List<bool>, Node) Compress(string text)
    {
        Dictionary<char, int> freq = GetFrequency(text);
        PriorityQueue<Node, int> queue = InitialiseQueue(freq);
        Node head = GetTree(queue);

        Dictionary<char, List<bool>> encoding = new Dictionary<char, List<bool>>();
        DFS(encoding, new List<bool>(), head);

        List<bool> result = text.Select(c => encoding[c]).SelectMany(x => x).ToList();

        return (result, head);
    }

    private static void DFS(Dictionary<char, List<bool>> encoding, List<Boolean> code, Node node)
    {
        if (node.lChild == null || node.rChild == null)
        {
            encoding.Add(node.symbol, new List<bool>(code));
        }
        else
        {
            code.Add(false);
            DFS(encoding, code, node.lChild);
            code.RemoveAt(code.Count -1);
            code.Add(true);
            DFS(encoding, code, node.rChild);
            code.RemoveAt(code.Count -1);
        }
    }

    private static Node GetTree(PriorityQueue<Node, int> queue)
    {
        while (queue.Count > 1)
        {
            Node a = queue.Dequeue();
            Node b = queue.Dequeue();
            Node c = new Node(a, b);
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
            queue.Enqueue(new Node(entry.Key, entry.Value), entry.Value);
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