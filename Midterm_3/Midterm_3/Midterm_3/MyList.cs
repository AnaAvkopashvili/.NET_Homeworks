using System.Collections;

class MyList<T> : IEnumerable<T>
{
    private T[] arr;
    private int size;
    public MyList()
    {
        arr = new T[2];
        size = 0;
    }
    public void Add(T item)
    {
        if (size == arr.Length)
        {
            T[] newArray = new T[arr.Length + 1];
            Array.Copy(arr, newArray, arr.Length);
            arr = newArray;
        }
        arr[size++] = item;
    }
    public void AddRange(IEnumerable<T> collection)
    {
        foreach (var item in collection)
        {
            if (size == arr.Length)
            {
                T[] newArray = new T[arr.Length * 2];
                Array.Copy(arr, newArray, arr.Length);
                arr = newArray;
            }
            arr[size++] = item;
        }
    }
    public void Remove(T item)
    {
        for (int i = 0; i < size; i++)
        {
            if (arr.ElementAt(i).Equals(item)) {
                Array.Copy(arr, i + 1, arr, i, size - i - 1);
                size--;
                return;
            }
        }
        throw new ArgumentException("The item you are trying to find could not be found in the list.");

    }
    public void RemoveRange(IEnumerable<T> collection)
    {
        foreach(var item in collection)
        {
            Remove(item);
        }
    }
    public void RemoveAt(int index)
    {
        if (index > 0 || index <= size)
        {
            Array.Copy(arr, index + 1, arr, index, size - index - 1);
            size--;
        }
        else
        {
            throw new ArgumentOutOfRangeException("the index you are trying to reach is out of range");
        }

    }
    public T this[int index]
    {
        get
        {
            if (index > 0 || index <= size)
            {
                return arr[index];

            }
            throw new ArgumentOutOfRangeException("the index you are trying to reach is out of range");

        }
    }

    public int Count { get { return size; } }

    public bool Contains(T item)
    {
        for (int i = 0; i < size; i++)
        {
            if (arr.ElementAt(i).Equals(item))
            {
                return true;
            }
        }
        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < size; i++)
        {
            yield return arr[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
