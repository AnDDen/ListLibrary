using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListLibrary;
using System.IO;

namespace Examples
{
    class Program
    {
        
        static void Main(string[] args)
        {
            #if DEBUG || _DEBUG
                StreamWriter _sw = new StreamWriter("output.txt");
                _sw.AutoFlush = true;
                Console.SetOut(_sw);
            #endif


            /*    ***************************************************
                  *                    Linked List                  *
                  ***************************************************    */

            Console.WriteLine("***** Testing LinkedList *****");
            IList<int> list = new LinkedList<int>();
            Console.WriteLine("Adding numbers from 1 to 10 to list");
            for (int i = 1; i <= 10; i++)
                list.Add(i);

            foreach (int elem in list) Console.Write("{0} ", elem);
            Console.WriteLine("\n\n");

            Console.WriteLine("Inserting 100 on position 0");
            list.Insert(0, 100);
            ListUtils.ForEach<int>(list, (x) => { Console.Write("{0} ", x); });
            Console.WriteLine("\n\n");

            Console.WriteLine("Inserting 1000 on position 11");
            list.Insert(11, 1000);
            for (int i = 0; i < list.Count; i++)
                Console.Write("{0} ", list[i]);
            Console.WriteLine("\n\n");

            Console.WriteLine("Inserting 10000 on position 5");
            list.Insert(5, 10000);
            ListUtils.ForEach<int>(list, (x) => { Console.Write("{0} ", x); });
            Console.WriteLine("\n\n");

            Console.WriteLine("Trying to insert 100 on position 15. Must be exception.");
            try
            {
                list.Insert(15, 100);
            }
            catch (ListException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\n");

            Console.WriteLine("Removing 100 from list");
            list.Remove(100);
            ListUtils.ForEach<int>(list, (x) => { Console.Write("{0} ", x); });
            Console.WriteLine("\n\n");

            Console.WriteLine("Removing element on position 0 from list");
            list.RemoveAt(0);
            ListUtils.ForEach<int>(list, (x) => { Console.Write("{0} ", x); });
            Console.WriteLine("\n\n");

            Console.WriteLine("Checking if 10000 is in list: {0}", list.Contains(10000));
            Console.WriteLine("Checking if 3 is in list: {0}, it's index = {1}", list.Contains(3), list.IndexOf(3));
            Console.WriteLine("\n");

            Console.WriteLine("Creating subList; fromIndex = 3; toIndex = 6;");
            IList<int> sub = list.subList(3, 6);
            ListUtils.ForEach<int>(sub, (x) => { Console.Write("{0} ", x); });
            Console.WriteLine("\n\n");

            Console.WriteLine("Count of elements in list: {0}\n", list.Count);
            Console.WriteLine("Clear list\n");
            list.Clear();
            Console.WriteLine("Count of elements in list: {0}\n", list.Count);
            Console.WriteLine("Writing elements of the list: ");
            ListUtils.ForEach<int>(list, (x) => { Console.Write("{0} ", x); });
            Console.WriteLine("if no one, then ok\n\n\n");

            Console.WriteLine("Adding numbers from 1 to 10 to list");
            for (int i = 1; i <= 10; i++)
                list.Add(i);
            Console.WriteLine("\n\n");

            /*    ***************************************************
                  *                    Unmutable List               *
                  ***************************************************    */

            Console.WriteLine("***** Testing UnmutableList *****\n");

            Console.WriteLine("Creating UnmutableList on base of list\n");
            list = new UnmutableList<int>(list);

            Console.WriteLine("Trying to add 12");
            try
            {
                list.Add(12);
            }
            catch (ListException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("if exception, then ok");
            ListUtils.ForEach<int>(list, (x) => { Console.Write("{0} ", x); });
            Console.WriteLine("\n\n");

            Console.WriteLine("Trying to insert 1000 on position 2");
            try
            {
                list.Insert(2, 1000);
            }
            catch (ListException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("if exception, then ok");
            ListUtils.ForEach<int>(list, (x) => { Console.Write("{0} ", x); });
            Console.WriteLine("\n\n");

            Console.WriteLine("Trying to remove 5 from list");
            try
            {
                list.Remove(5);
            }
            catch (ListException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("if exception, then ok");
            ListUtils.ForEach<int>(list, (x) => { Console.Write("{0} ", x); });
            Console.WriteLine("\n\n");

            Console.WriteLine("Checking if 10000 is in list: {0}\n", list.Contains(10000));
            Console.WriteLine("Checking if 3 is in list: {0}, it's index = {1}\n", list.Contains(3), list.IndexOf(3));
            Console.WriteLine("\n");

            Console.WriteLine("Creating subList; fromIndex = 3; toIndex = 6;\n");
            sub = list.subList(3, 6);
            ListUtils.ForEach<int>(sub, (x) => { Console.Write("{0} ", x); });
            Console.WriteLine("\n\n");

            Console.WriteLine("Count of elements in list: {0}\n", list.Count);
            Console.WriteLine("Clear list\n");
            try
            {
                list.Remove(5);
            }
            catch (ListException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Count of elements in list: {0}\n\n", list.Count);
            Console.WriteLine("\n\n");


            /*    ***************************************************
                  *                    Array List                   *
                  ***************************************************    */

            Console.WriteLine("***** Testing ArrayList *****\n");
            list = new ArrayList<int>();
            Console.WriteLine("Adding numbers from 1 to 10 to list");
            for (int i = 1; i <= 10; i++)
                list.Add(i);

            foreach (int elem in list) Console.Write("{0} ", elem);
            Console.WriteLine("\n\n");

            Console.WriteLine("Inserting 100 on position 0");
            list.Insert(0, 100);
            ListUtils.ForEach<int>(list, (x) => { Console.Write("{0} ", x); });
            Console.WriteLine("\n\n");

            Console.WriteLine("Inserting 1000 on position 11");
            list.Insert(11, 1000);
            for (int i = 0; i < list.Count; i++)
                Console.Write("{0} ", list[i]);
            Console.WriteLine("\n\n");

            Console.WriteLine("Inserting 10000 on position 5");
            list.Insert(5, 10000);
            ListUtils.ForEach<int>(list, (x) => { Console.Write("{0} ", x); });
            Console.WriteLine("\n\n");

            Console.WriteLine("Trying to insert 100 on position 15. Must be exception.");
            try
            {
                list.Insert(15, 100);
            }
            catch (ListException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\n");

            Console.WriteLine("Removing 100 from list");
            list.Remove(100);
            ListUtils.ForEach<int>(list, (x) => { Console.Write("{0} ", x); });
            Console.WriteLine("\n\n");

            Console.WriteLine("Removing element on position 0 from list");
            list.RemoveAt(0);
            ListUtils.ForEach<int>(list, (x) => { Console.Write("{0} ", x); });
            Console.WriteLine("\n\n");

            Console.WriteLine("Checking if 10000 is in list: {0}", list.Contains(10000));
            Console.WriteLine("Checking if 3 is in list: {0}, it's index = {1}", list.Contains(3), list.IndexOf(3));
            Console.WriteLine("\n");

            Console.WriteLine("Creating subList; fromIndex = 3; toIndex = 6;");
            sub = list.subList(3, 6);
            ListUtils.ForEach<int>(sub, (x) => { Console.Write("{0} ", x); });
            Console.WriteLine("\n\n");

            Console.WriteLine("Count of elements in list: {0}\n", list.Count);
            Console.WriteLine("Clear list\n");
            list.Clear();
            Console.WriteLine("Count of elements in list: {0}\n", list.Count);
            Console.WriteLine("Writing elements of the list: ");
            ListUtils.ForEach<int>(list, (x) => { Console.Write("{0} ", x); });
            Console.WriteLine("if no one, then ok\n\n\n");
            Console.WriteLine("\n\n");


            /*    ***************************************************
                  *                    List Utils                   *
                  ***************************************************    */

            Console.WriteLine("***** Testing ListUtils *****\n");
            list = new LinkedList<int>();
            Console.WriteLine("Adding numbers from 1 to 10 to list");
            for (int i = 1; i <= 10; i++)
                list.Add(i);
            ListUtils.ForEach(list, (x) => { Console.Write("{0} ", x); });
            Console.WriteLine();

            Console.WriteLine("Is there even element: {0}", ListUtils.Exists(list, (x) => { return x % 2 == 0; }));
            Console.WriteLine("First even element: {0}, it's index: {1}", ListUtils.Find(list, (x) => { return x % 2 == 0; }), 
                                                                        ListUtils.FindIndex(list, (x) => { return x % 2 == 0; }));
            Console.WriteLine("Last even element: {0}, it's index: {1}", ListUtils.FindLast(list, (x) => { return x % 2 == 0; }),
                                                                    ListUtils.FindLastIndex(list, (x) => { return x % 2 == 0; }));
            IList<int> even = ListUtils.FindAll(list, (x) => { return x % 2 == 0; }, () => { return new LinkedList<int>(); });
            Console.Write("All even elements:");
            ListUtils.ForEach(even, (x) => { Console.Write(" {0}", x); });
            Console.WriteLine();

            Console.WriteLine("Sorting list by decrease");
            ListUtils.Sort(list, (x, y) => { return y.CompareTo(x); });
            ListUtils.ForEach(list, (x) => { Console.Write("{0} ", x); });
            Console.WriteLine();

            Console.WriteLine("Check if all elements of list are even: {0}", ListUtils.CheckForAll(list, (x) => { return x % 2 == 0; }));
            Console.WriteLine("Check if all elements of list are less than 12: {0}", ListUtils.CheckForAll(list, (x) => { return x < 12; }));

            Console.WriteLine("Convert int list to string list");
            IList<string> strlist = ListUtils.ConvertAll<int, string>(list, (x) => { return x.ToString(); }, () => { return new ArrayList<string>(); });
            Console.WriteLine("strlist type: {0}", strlist.GetType().Name);
            Console.WriteLine("Elements of strlist");
            ListUtils.ForEach(strlist, (x) => { Console.Write("{0} ", x); });
            Console.WriteLine();
        }
    }
}
