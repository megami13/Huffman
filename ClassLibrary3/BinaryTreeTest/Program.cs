using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryTree;

namespace BinaryTreeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "abbccccddddeeeeeeeffffff";
            string[] tab = new string[text.Length];

            for (int j = 0; j < text.Length; j++)
            {
                char letter_text_char = text[j];
                tab[j] = Convert.ToString(letter_text_char);
            }

            var querry1 = tab.Select(n => n).ToArray();

            foreach (var group in querry1.GroupBy(s => s))
                Console.WriteLine("{0} = {1}", group.Key, group.Count());

            Tree<int> tree = new Tree<int>(0, null, "x");
            
            foreach (var group in tab.GroupBy(s => s))
            {
                tree.Insert(Convert.ToInt32(group.Count()), group.Key);
            }

            string[] tab1 = new string[tab.Length];
            tree.WalkTree();

            Console.ReadKey();
            
            /*
            Tree<int> tree = new Tree<int>(20, null, "a");

            tree.Insert(3, "a");
            tree.Insert(10, "b");
            tree.Insert(1, "a");
            tree.Insert(4, "a");
            tree.Insert(-1, "a");
            tree.Insert(0, "a");
            tree.Insert(4, "a");
            tree.Insert(7, "a");
            tree.Insert(15, "a");
            tree.Insert(16, "a");
            tree.Insert(19, "a");
            tree.Insert(8, "a");
            tree.Insert(10, "a");
            tree.Insert(9, "a");
            tree.WalkTree();
            Console.ReadKey();
            */
        }
    }
}
