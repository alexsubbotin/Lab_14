using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subb_Lab_14
{
    class MyNewDictionary<K, T>: MyDictionary<K, T> 
    {
        // Delegate for events.
        public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);

        // Collection name.
        public string Name { get; set; }

        // Remove from the j position.
        public bool Remove(int j)
        {
            if (j > Capacity)
                return false;
            else
            {
                base.Remove(Table[j]);
                return true;
            }
        }

        // Indexer.
        public DicPoint<K,T> this[int index]
        {
            get
            {
                if (index >= 0 && index < Capacity)
                    return Table[index];
                else
                    throw new IndexOutOfRangeException();
            }

            set
            {
                if (index >= 0 && index < Capacity)
                    Table[index] = value;
                else
                    throw new IndexOutOfRangeException();
            }
        }
    }
}
