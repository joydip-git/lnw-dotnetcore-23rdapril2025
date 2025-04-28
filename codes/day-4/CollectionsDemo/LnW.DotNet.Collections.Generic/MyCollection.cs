using System.Collections;

namespace LnW.DotNet.Collections.Generic
{
    public class MyCollection<T> : IEnumerable<T>
    {
        T[] elements;
        int index = 0;
        public MyCollection()
        {
            elements = new T[4];
        }

        public int Count => index;

        public int Capacity => elements.Length;

        public void Add(T item)
        {
            if (index == elements.Length)
            {
                T[] temp = new T[elements.Length * 2];
                elements.CopyTo(temp, 0);
                elements = temp;
            }
            elements[index] = item;
            index++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < index; i++)
            {
                yield return elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int x]
        {
            get { return elements[x]; }
            set { elements[x] = value; }
        }

        public void Sort()
        {
            if (typeof(T).GetInterface("System.IComparable") != null)
            {
                //code for sorting...
            }
            else
                throw new InvalidOperationException();
        }
    }
}
