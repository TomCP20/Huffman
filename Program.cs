﻿using System.Collections;
using System.Text;
using System.Xml.XPath;

namespace Huffman;

static class Program
{
    static string LoremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        
    static void Main()
    {
        Console.Write("Enter the desired text (press enter for default):");
        string? input = Console.ReadLine();
        if (input == "" || input == null)
        {
            input = LoremIpsum;
        }


        (BitArray compressed, Node tree) = Compression.Compress(input);
        
        string decompressed = Decompression.Decompress(compressed, tree);

        Console.WriteLine(input);
        Console.WriteLine();
        StringBuilder sb = new();
        foreach (bool bit in compressed)
        {
            sb.Append(bit ? 1 : 0);
        }
        Console.WriteLine(sb.ToString());
        Console.WriteLine();
        Console.WriteLine(decompressed);
        Console.WriteLine();
        if (input == decompressed)
        {
            Console.WriteLine("Compression successful.");
        }
        else
        {
            Console.WriteLine("Compression failed.");
        }
    }
}
