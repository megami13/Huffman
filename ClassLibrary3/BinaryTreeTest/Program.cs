using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryTree;
using System.IO;

namespace BinaryTreeTest
{
    public static class Extensions
    {
        public static Dictionary<char, int> CharacterCount(this string text)
        {
            return text.GroupBy(c => c)
                       .OrderBy(c => c.Key)
                       .ToDictionary(grp => grp.Key, grp => grp.Count());
        }
    }

    static class Program
    {

        public static string RemoveWhitespace(this string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }

        static void Main(string[] args)
        {
            string text = null;

            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("C:/GIT/test.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    text = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

           // text = "Kotek cos tam cos tam";

            //usuwamy spacje dla prostoty
            text = RemoveWhitespace(text);

            var countsTable = text.CharacterCount().ToList();

            var frequenciesTable = countsTable.OrderByDescending(c => c.Value).ToList();

            
           
            Tree<int> tree = new Tree<int>(frequenciesTable[0].Value, null, frequenciesTable[0].Key.ToString());

            for(var i = 1; i<frequenciesTable.Count; i++)
            {
                tree.Insert(frequenciesTable[i].Value, frequenciesTable[i].Key.ToString());
            }

            //foreach (var frequencyRow in frequenciesTable)
            //{

            //       Console.Write(frequencyRow.Key);
            //       Console.WriteLine(frequencyRow.Value);

            //}


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