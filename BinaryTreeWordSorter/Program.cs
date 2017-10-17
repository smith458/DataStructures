using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryTree;

namespace BinaryTreeWordSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<string> tree = new BinaryTree<string>();

            string input = string.Empty;

            while (!input.Equals("quit", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.Write("> ");
                input = Console.ReadLine();

                string[] words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in words)
                {
                    tree.Add(word);
                }

                Console.WriteLine("{0} words", tree.Count);

                foreach (string word in tree)
                {
                    Console.Write("{0} ", word);
                }

                Console.WriteLine();
                tree.Clear();
            }

        }
    }
}
