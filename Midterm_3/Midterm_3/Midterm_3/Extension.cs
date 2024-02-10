namespace Midterm_3
{
    internal static class Extension<T>
    {
        private static T[] arr;
        private static int size;
        public static T First(Predicate<T> predicate)
        {
            for (int i = 0; i < size; i++)
            {
                if (predicate(arr[i]))
                {
                    return arr[i];
                }
            }
            throw new InvalidOperationException("The element you are trying to find could not be found");
        }

        public static T FirstOrDefault(Predicate<T> predicate)
        {
            for (int i = 0; i < size; i++)
            {
                if (predicate(arr[i]))
                {
                    return arr[i];
                }
            }
            return default(T);
        }

        public static IEnumerable<T> Where(Func<T, bool> predicate)
        {
            for (int i = 0; i < size; i++)
            {
                if (predicate(arr[i]))
                {
                    yield return arr[i];
                }
            }
            throw new InvalidOperationException("The elements you are trying to find could not be found");
        }
        public static IEnumerable<T> Distinct(Func<T, bool> predicate)
        {
            List<T> lst = new List<T>();
            for (int i = 0; i < size; i++)
            {
                if (predicate(arr[i]))
                {
                    if (!lst.Contains(arr[i]))
                    {
                        lst.Add(arr[i]);
                    }
                 throw new InvalidOperationException("The elements you are trying to find could not be found");
                }
            }
            foreach(var item in lst)
            {
                yield return item;
            }
        }
    }
}
