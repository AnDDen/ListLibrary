using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListLibrary.Classes
{
    internal class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data, Node<T> next)
        {
            Data = data;
            Next = next;
        }
    }

    public class LinkedList<T> : IList<T>
    {
        private Node<T> first;
        private int count;

        public LinkedList()
        {
            first = null;
            count = 0;
        }

        public void Add(T value)
        {
            if (first == null)
                first = new Node<T>(value, null);
            else
            {
                Node<T> p = first;
                while (p.Next != null) p = p.Next;
                p.Next = new Node<T>(value, null);
            }
            count++;
        }

        public void Clear()
        {
            first = null;
            count = 0;
        }

        public bool Contains(T value)
        {
            Node<T> p = first;
            while (p.Next != null)
                if (p.Data.Equals(value)) return true;
                else p = p.Next;
            return false;
        }

        public int IndexOf(T value)
        {
            int i = 0;
            Node<T> p = first;
            while (p.Next != null)
                if (p.Data.Equals(value)) return i;
                else
                {
                    p = p.Next;
                    i++;
                }
            return -1;
        }

        public void Insert(int index, T value)
        {
            if (index < 0 || index > count)
                throw new ListException("Index is out of range");

            int i = 0;
            Node<T> p = first;
            while (i != index - 1)
            {
                p = p.Next;
                i++;
            }
            p.Next = new Node<T>(value, p.Next);
            count++;
        }

        public void Remove(T value)
        {
            Node<T> p = first;
            while (p.Next != null)
                if (p.Next.Data.Equals(value))
                {
                    p.Next = p.Next.Next;
                    return;
                }
                else p = p.Next;
            count--;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                throw new ListException("Index is out of range");

            int i = 0;
            Node<T> p = first;
            while (i != index - 1)
            {
                p = p.Next;
                i++;
            }
            p.Next = p.Next.Next;
            count--;
        }

        public IList<T> subList(int fromIndex, int toIndex)
        {
            if (fromIndex < 0 || fromIndex >= count)
                throw new ListException("fromIndex is out of range");

            if (toIndex < 0 || toIndex >= count)
                throw new ListException("toIndex is out of range");

            LinkedList<T> sub = new LinkedList<T>();

            int i = 0;
            Node<T> p = first;
            while (p.Next != null)
            {
                if (i >= fromIndex && i <= toIndex)
                    sub.Add(p.Data);
                p = p.Next;
                i++;
            }

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

                int i = 0;
                Node<T> p = first;
                while (i != index)
                {
                    p = p.Next;
                    i++;
                }

                return p.Data;
            }
            set
            {
                if (index < 0 || index > count)
                    throw new ListException("Index is out of range");

                if (index == count)
                    Add(value);
                else
                {
                    int i = 0;
                    Node<T> p = first;
                    while (i != index)
                    {
                        p = p.Next;
                        i++;
                    }

                    p.Data = value;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> p = first;
            while (p != null)
            {
                yield return p.Data;
                p = p.Next;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
