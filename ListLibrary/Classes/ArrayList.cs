using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ListLibrary
{
    public class ArrayList<T> : IList<T>
    {
        private T[] array;
        private T[] tempArray;

        private int count;

        public ArrayList()
        {
            array = new T[0];
            count = 0;
        }
        
        public void Add(T value)
        {
            tempArray = new T[count + 1];
            for (int i = 0; i < count; i++)
                tempArray[i] = array[i];
            tempArray[count++] = value;
            array = tempArray;
        }

        public void Clear()
        {
            array = new T[0];
            count = 0;
        }

        public bool Contains(T value)
        {
            foreach (T elem in array)
                if (elem.Equals(value)) return true;
            return false;
        }

        public int IndexOf(T value)
        {
            for (int i = 0; i < count; i++)
                if (array[i].Equals(value)) return i;
            return -1;
        }

        public void Insert(int index, T value)
        {
            if (index < 0 || index > count)
                throw new ListException("Index is out of range");

            tempArray = new T[count + 1];
            for (int i = 0; i < index; i++)
                tempArray[i] = array[i];
            tempArray[index] = value;
            for (int i = index + 1; i < count + 1; i++)
                tempArray[i] = array[i - 1];
            array = tempArray;
            count++;
        }

        public void Remove(T value)
        {
            if (!Contains(value))
                return;

            int k = 0;
            while (!array[k].Equals(value)) k++;

            RemoveAt(k);
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                throw new ListException("Index is out of range");

            tempArray = new T[--count];
            for (int i = 0; i < index; i++)
                tempArray[i] = array[i];
            for (int i = index; i < count; i++)
                tempArray[i] = array[i + 1];
            array = tempArray;

            count--;
        }

        public IList<T> subList(int fromIndex, int toIndex)
        {
            if (fromIndex < 0 || fromIndex >= count)
                throw new ListException("fromIndex is out of range");

            if (toIndex < 0 || toIndex >= count)
                throw new ListException("toIndex is out of range");

            ArrayList<T> sub = new ArrayList<T>();
            for (int i = fromIndex; i <= toIndex; i++)
                sub.Add(array[i]);

            return sub;
        }

        public int Count
        {
            get { return count; }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    throw new ListException("Index is out of range");

                return array[index];
            }
            set
            {
                if (index < 0 || index > count)
                    throw new ListException("Index is out of range");

                if (index == count)
                    Add(value);
                else
                    array[index] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
                yield return this[i];
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
