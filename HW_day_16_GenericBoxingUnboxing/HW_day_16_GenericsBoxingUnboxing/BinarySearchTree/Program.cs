namespace BinarySearchTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tree<int> intTree = new Tree<int>();
            intTree.Insert(1);
            intTree.Insert(2);
            intTree.Insert(3);
            intTree.Insert(4);
            intTree.Insert(5);
            intTree.Insert(6);

            Node<int> searching = intTree.Search(7);
            if (searching != null)
            {
                Console.WriteLine("Found");
            }
            else
            {
                Console.WriteLine("not found");
            }

        }
    }
}