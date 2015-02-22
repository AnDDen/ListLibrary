using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListLibrary.Classes;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            ListLibrary.IList<int> list = new ListLibrary.Classes.LinkedList<int>();
            list.Add(5);
            list.Add(6);
            list.Add(7);
            
            foreach (int i in list)
                Console.WriteLine(i);
            Console.ReadKey();

            List<int> l = new List<int>();
        }
    }
}
