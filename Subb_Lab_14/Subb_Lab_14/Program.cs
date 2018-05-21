using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subb_Lab_14
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.Clear();

                Console.WriteLine(@"Choose one of the options:
1. Work with MyDictionary
2. Demonstrate the events
3. Exit");

                choice = MyDicDemo.ChoiceInput(3);

                switch (choice)
                {
                    case 1:
                        MyDicDemo.Demonstrate();
                        break;
                    case 2:
                        EventsDemo();
                        break;
                }
            } while (choice != 3);
        }

        public static void EventsDemo()
        {
            Console.Clear();


            // The first collection.

            MyNewDictionary<int, State> dic1 = new MyNewDictionary<int, State>();

            MyDictionary<int, State> buf = new MyDictionary<int, State>(4);
            MyDicDemo.FillDic(ref buf);

            dic1 = new MyNewDictionary<int, State>(buf);

            dic1.Name = "dic1";

            // The second collection.
            MyNewDictionary<int, State> dic2 = new MyNewDictionary<int, State>(4);

            buf = new MyDictionary<int, State>(4);
            MyDicDemo.FillDic(ref buf);

            dic2 = new MyNewDictionary<int, State>(buf);

            dic2.Name = "dic2";

            // The first journal.
            Journal journal1 = new Journal();

            // The second journal.
            Journal journal2 = new Journal();

            // Subscription of the first journal.
            dic1.CollectionCountChanged += new CollectionHandler(journal1.CollectionCountChanged);
            dic1.CollectionReferenceChanged += new CollectionHandler(journal1.CollectionReferenceChanged);

            // Subscription of the second journal.
            dic1.CollectionReferenceChanged += new CollectionHandler(journal2.CollectionReferenceChanged);
            dic2.CollectionReferenceChanged += new CollectionHandler(journal2.CollectionReferenceChanged);

            // Generating a random state object.
            State rnd = MyDicDemo.RandomState();

            // Adding the elem to the 1st collection.
            dic1.Add(rnd.Name.Length, rnd);
            // Removing an object from the 1st collection.
            dic1.Remove(0);
            // Changing a value int the 1st collection.
            dic1.Remove(rnd);
            DicPoint<int, State> dicPointBuf = new DicPoint<int, State>(rnd.Name.Length, rnd);
            dic1.Table[0] = dicPointBuf;

            // Adding the elem to the 2nd collection.
            dic2.Add(rnd.Name.Length, rnd);
            // Removing an object from the 2nd collection.
            dic2.Remove(0);
            // Changing a value int the 2nd collection.
            dic2.Remove(rnd);
            dicPointBuf = new DicPoint<int, State>(rnd.Name.Length, rnd);
            dic2.Table[0] = dicPointBuf;

            Console.WriteLine(journal1.ToString());
            Console.WriteLine(journal2.ToString());

            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
        }
    }
}
