using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    /*
     * Do tej klasy będzie potrzebny interfejs IComparable od T , który musi łączyć się z naszym typem T. Nie trzeba go implementować, 
     * ten fragment pozwala nam na użycie każdego typu danych, musi on jednak implementować ten interfejs i mimo, iż nie znamy jego typu. 
     * W tym kodzie będziemy mogli skorzystać z jego metody CompareTo(). Jest możliwe dzięki magii słowa kluczowego where.
    */
    public class Tree<TItem> where TItem : IComparable<TItem>
    {
        /*
        Następnie trzeba dodać automatyczne właściwości, które są typami od T.Drzewo działa rekursywnie, więc klasa zawierać będzie dwie 
        właściwości, które są klasami generycznymi Tree czyli są to poddrzewa, które mogą mieć kolejne drzewa.Każde drzewo oprócz lewego 
        i prawego poddrzewa zawiera jeszcze wartość obiektu, w naszym przypadku jest to typ T czyli TItem.
        */
        public TItem NodeData { get; set; }
        public Tree<TItem> LeftTree { get; set; }
        public Tree<TItem> RightTree { get; set; }
        public Tree<TItem> ParentTree { get; set; }
        public string letter { get; set; }

        //List<Tree<TItem>> objList = new List<Tree<TItem>>();

        public Tree(TItem nodeValue, Tree<TItem> parent, string Letter) // konstruktor
        {
            this.NodeData = nodeValue;
            this.LeftTree = null;
            this.RightTree = null;
            this.ParentTree = parent;
            this.letter = Letter;
        }

        public void Insert(TItem newItem, string letter) // implementuje rekursywny algorytm
        {
            TItem currentNodeValue = this.NodeData;
            
            if (currentNodeValue.CompareTo(newItem) > 0)
            {
                // tutaj ma trafić element do lewego poddrzewa
                if (this.LeftTree == null)
                {
                    this.LeftTree = new Tree<TItem>(newItem, this, letter);
                }
                else
                {
                    this.LeftTree.Insert(newItem, letter);
                    //this.LeftTree.ParentTree = this;
                }
            }
            else
            {
                // tutaj element ma trafić do prawego poddrzewa
                if (this.RightTree == null)
                {
                    this.RightTree = new Tree<TItem>(newItem, this, letter);
                }
                else
                {
                    this.RightTree.Insert(newItem, letter);
                    //this.RightTree.ParentTree = this;
                }
            }
        }
        static string i;
        public void WalkTree()
        {
            if (this.RightTree != null)
            {
                this.RightTree.WalkTree();
                i = i + "1";
            }
            Console.Write(this.NodeData.ToString() + ", " + this.letter + ", ");
            Console.WriteLine(i);
            
            /*
            if (ParentTree != null)
            {
                Console.WriteLine(this.ParentTree.NodeData.ToString());
            }
            else
            {
                Console.WriteLine();
            }
            */
            if (this.LeftTree != null)
            {
                this.LeftTree.WalkTree();
                i = i + "0";
            }
        }
    }
}
