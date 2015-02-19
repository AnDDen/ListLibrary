using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListLibrary.Classes
{
    public class ListUtils
    {
        public delegate bool CheckDelegate<T>(T value);
        public delegate IList<T> ListConstructorDelegate<T>();
        public delegate TO ConvertDelegate<in TI, out TO>(TI input);
        public delegate void ActionDelegate<T>(T value);
        public delegate int CompareDelegate<T>(T x, T y);

        public static bool Exists<T>(IList<T> list, CheckDelegate<T> check){
            throw new Exception();
        }
        public static T Find<T>(IList<T> list, CheckDelegate<T> check){
            throw new Exception();
        }
        public static T FindLast<T>(IList<T> list, CheckDelegate<T> check){
            throw new Exception();
        }
        public static int FindIndex<T>(IList<T> list, CheckDelegate<T> check){
            throw new Exception();
        }
        public static int FindLastIndex<T>(IList<T> list, CheckDelegate<T> check){
            throw new Exception();
        }
        public static IList<T> FindAll<T>(IList<T> list, CheckDelegate<T> check, ListConstructorDelegate<T> constructor){
            throw new Exception();
        }
        public static IList<TO> ConvertAll<TI, TO>(IList<TI> list, ConvertDelegate<TI, TO> converter, ListConstructorDelegate<TO> constructor){
            throw new Exception();
        }
        public static void ForEach<T>(IList<T> list, ActionDelegate<T> action){

        }
        public static void Sort<T>(IList<T> list, CompareDelegate<T> comparer){

        }
        public static bool CheckForAll<T>(IList<T> list, CheckDelegate<T> check){
            throw new Exception();
        }

    }
}
