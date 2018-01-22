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
        static string text;
        int n = text.Length;

        static void a(string[] tab, string text)
        {
            char[] tab_ = new char[text.Length];
            int n = text.Length;

            for (int j = 0; j < text.Length; j++)
            {
                char letter_text_char = text[j];
                //string letter_text = Convert.ToString(letter_text_char) + "0";
                tab[j] = Convert.ToString(letter_text_char);
            }

                var dict = new Dictionary<string, int>();
            foreach (var i in tab)
                if (dict.ContainsKey(i))
                    dict[i]++;
                else
                    dict[i] = 1;

            foreach (var group in tab.GroupBy(s => s))
                Console.WriteLine("{0} = {1}", group.Key, group.Count());
            /*
            for (int j = 0; j < text.Length; j++)
            {
                char letter_text_char = text[j];
                //string letter_text = Convert.ToString(letter_text_char) + "0";
                tab_[j] = letter_text_char;
            }
            for (int m = 0; m < text.Length; m++)
            {
                char letter_text_char = text[m];
                //string letter_text = Convert.ToString(letter_text_char) + "0";
                tab[m] = Convert.ToString(letter_text_char) + "0";
            }
            
            for (int i = 0; i < text.Length; i++)
            {
                for (int k = 0; k < i; k++)
                {
                    char letter = text[i];
                    char letter_tab = tab[k][0];

                    if (i == 0)
                    {
                        tab[0] = Convert.ToString(letter) + "1";
                    }
                    if (letter == letter_tab)
                    {
                        char tab_letter_count = tab[k][1];
                        tab[k] = tab[k] + "1";
                        break;
                    }
                    else
                    {
                        tab[i] = Convert.ToString(letter) + "1";
                    }
                }
            }
            */
            /*
            for (int i = 0; i < text.Length; i++)
            {
                for (int k = 0; k < text.Length; k++)
                {
                    char letter = text[k];
                    char letter_tab = tab[i][0];

                    if (letter_tab == letter)
                    {
                        char tab_letter_count = tab[i][1];
                        int tab_letter_count_int = Convert.ToInt32(tab_letter_count);

                        tab_letter_count_int = tab_letter_count_int + 1;

                        string tab_new_letter_number = Convert.ToString(tab_letter_count_int);
                        tab[i] = letter + tab_new_letter_number;
                        tab[i] = tab[i].Replace(tab[i], letter + tab_new_letter_number);
                    }
                }
            }
            
            char letter;
            char letter_tab;

            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < text.Length; j++)
                {
                    letter = text[j];
                    letter_tab = tab_[i];
                    
                    if (letter == letter_tab)
                    {
                        char tab_letter_count = tab[i][1];
                        int tab_letter_count_int = Convert.ToInt32(tab_letter_count);

                        tab_letter_count_int = tab_letter_count_int + 1;

                        string tab_new_letter_number = Convert.ToString(tab_letter_count_int);
                        tab[i] = tab[i].Replace(tab[i], letter + tab_new_letter_number);
                    }
                }
            }*/


        }

        static void Main(string[] args)
        {
            string text = "kotek nazywa sie misiek";
            string[] tab = new string[text.Length];

            for (int j = 0; j < text.Length; j++)
            {
                char letter_text_char = text[j];
                tab[j] = Convert.ToString(letter_text_char);
            }

            var querry1 = tab.Select(n => n).ToArray();

            foreach (var group in querry1.GroupBy(s => s))
                Console.WriteLine("{0} = {1}", group.Key, group.Count());


            foreach (var group in querry1.GroupBy(s => s))
            {
                //tab = group.Key + group.Count();
            }

            var asd = tab.Select(n => n).ToArray().GroupBy(s => s);
            var query3 = asd.Select(n => n).ToArray().OrderByDescending(c => c);
            /*
            foreach (var item in asd)
            {
                Console.Write(item + " ");
            }
            */
            Tree<int> tree = new Tree<int>(0, null, "a");
            
            foreach (var group in tab.GroupBy(s => s))
            {
                tree.Insert(Convert.ToInt32(group.Count()), group.Key);
            }

            string[] tab1 = new string[tab.Length];
            tree.WalkTree();


            //Console.WriteLine("{0} = {1}", group.Key, group.Count());

            //tree.WalkTree();

            //List<Tree<int>> objList = new List<Tree<int>>();
            //List<Tree<int>> SortedList = objListOrder.OrderBy(o => o.NodeData).ToList();


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
