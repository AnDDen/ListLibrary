using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListLibrary
{
    public class UnmutableList<T> : IList<T>
    {
        private IList<T> baseList;

        public UnmutableList(IList<T> baseList)
        {
            if (baseList is UnmutableList<T>) 
                throw new ListException("UnmutableList can not be base for UnmutableList");
            this.baseList = baseList;
        }

        public void Add(T value)
        {
            throw new ListException("New elements can not be added to UnmutableList");
        }

        public void Clear()
        {
            throw new ListException("UnmutableList can not be cleared");
        }

        public bool Contains(T value)
        {
            return baseList.Contains(value);
        }

        public int IndexOf(T value)
        {
            return baseList.IndexOf(value);
        }

        public void Insert(int index, T value)
        {
            throw new ListException("New elements can not be added to UnmutableList");
        }

        public void Remove(T value)
        {
            throw new ListException("Elements can not be removed from UnmutableList");
        }

        public void RemoveAt(int index)
        {
            throw new ListException("Elements can not be removed from UnmutableList");
        }

        public IList<T> subList(int fromIndex, int toIndex)
        {
            return baseList.subList(fromIndex, toIndex);
        }

        public int Count
        {
            get { return baseList.Count; }
        }

        public T this[int index]
        {
            get
            {
                return baseList[index];
            }
            set
            {
                throw new ListException("Elements can not be changed in UnmutableList");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < baseList.Count; i++)
                yield return baseList[i];
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
