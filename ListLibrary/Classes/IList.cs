using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListLibrary
{
    public interface IList<T> : IEnumerable<T>
    {
        //методы
        void Add(T value);
        void Clear();
        bool Contains(T value);
        int IndexOf(T value);
        void Insert(int index, T value);
        void Remove(T value);
        void RemoveAt(int index);
        IList<T> subList(int fromIndex, int toIndex);
        
        //свойства
        int Count { get; }
        T this[int index] { get; set; }
    }

    public class ListException : ApplicationException
    {
        public ListException(string message) : base(message) { }
    }
}
