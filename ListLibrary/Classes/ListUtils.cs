using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListLibrary
{
    public class ListUtils
    {
        public delegate bool CheckDelegate<T>(T value);
        public delegate IList<T> ListConstructorDelegate<T>();
        public delegate TO ConvertDelegate<in TI, out TO>(TI input);
        public delegate void ActionDelegate<T>(T value);
        public delegate int CompareDelegate<T>(T x, T y);

        public static bool Exists<T>(IList<T> list, CheckDelegate<T> check)
        {
            if (check == null) throw new ListException("Argument check can not be null.");
            foreach (T obj in list)
                if (check(obj)) return true;
            return false;
        }

        public static T Find<T>(IList<T> list, CheckDelegate<T> check)
        {
            if (check == null) throw new ListException("<check> can not be null.");
            foreach (T obj in list)
                if (check(obj)) return obj;
            return default(T);
        }

        public static T FindLast<T>(IList<T> list, CheckDelegate<T> check)
        {
            if (check == null) throw new ListException("<check> can not be null.");
            T res = default(T);
            foreach (T obj in list)
                if (check(obj)) res = obj;
            return res;
        }

        public static int FindIndex<T>(IList<T> list, CheckDelegate<T> check)
        {
            if (check == null) throw new ListException("<check> can not be null.");
            for (int i = 0; i < list.Count; i++)
                if (check(list[i])) return i;
            return -1;
        }

        public static int FindLastIndex<T>(IList<T> list, CheckDelegate<T> check)
        {
            if (check == null) throw new ListException("<check> can not be null.");
            int res = -1;
            for (int i = 0; i < list.Count; i++)
                if (check(list[i])) res = i;
            return res;
        }

        public static IList<T> FindAll<T>(IList<T> list, CheckDelegate<T> check, ListConstructorDelegate<T> constructor)
        {
            IList<T> result = constructor();
            foreach (T obj in list)
                if (check(obj)) result.Add(obj);
            return result;
        }

        public static IList<TO> ConvertAll<TI, TO>(IList<TI> list, ConvertDelegate<TI, TO> converter, ListConstructorDelegate<TO> constructor)
        {
            IList<TO> result = constructor();
            foreach (TI obj in list)
                result.Add(converter(obj));
            return result;
        }

        public static void ForEach<T>(IList<T> list, ActionDelegate<T> action)
        {
            foreach (T obj in list)
                action(obj);
        }

        public static void Sort<T>(IList<T> list, CompareDelegate<T> comparer)
        {
            int n = list.Count;
            for (int i = 1; i < n; i++)
            {
                for (int j = n - 1; j >= i; j--)
                    if (comparer(list[j - 1], list[j]) > 0)
                    {
                        T t = list[j - 1];
                        list[j - 1] = list[j];
                        list[j] = t;
                    }
            }
        }

        public static bool CheckForAll<T>(IList<T> list, CheckDelegate<T> check)
        {
            foreach (T obj in list)
                if (!check(obj)) return false;
            return true;
        }
    }
}
