namespace Generics
{

        class Program
        {
            public static void GenericSwap<T>(T[] array, T value1, T value2)
            {
                if (array != null && array.Length >= 2 && value1 != null && value2 != null)
                {
                    int index1 = Array.IndexOf(array, value1);
                    int index2 = Array.IndexOf(array, value2);
                    if (index1 >= 0 && index2 >= 0)
                    {
                        T temp = array[index1];
                        array[index1] = array[index2];
                        array[index2] = temp;
                    }
                }
            }

            public static T GenericMaximumFinder<T>(T[] array) where T : IComparable<T>
            {
                T max = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i].CompareTo(max) > 0)
                        max = array[i];
                }
                return max;
            }
            static void Main(string[] args)
            {
                //int[] ints = { 0, 1, 2, 3, 4 };

                //GenericSwap<int>(ints, 1, 2);
                //foreach (int num in ints)
                //{
                //    Console.Write(num + " ");
                //}
                //Console.WriteLine();

                //Console.WriteLine(GenericMaximumFinder<int>(ints).ToString());
           
        }
    }
}