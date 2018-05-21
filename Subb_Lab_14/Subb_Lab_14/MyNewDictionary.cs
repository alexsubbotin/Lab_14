using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subb_Lab_14
{
    // Delegate for events.
    delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);

    class MyNewDictionary<K, T>: MyDictionary<K, T> 
    {
        // Collection name.
        public string Name { get; set; }

        // Remove from the j position.
        public bool Remove(int j)
        {
            if (j > Capacity)
                return false;
            else
            {
                // Creating an event.
                CollectionHandlerEventArgs args = new CollectionHandlerEventArgs(Name, "Object is removed", Table[j].value as State);
                CollectionCountChanged(Name, args);


                base.Remove(Table[j]);
                return true;
            } 
        }

        // Add with event.
        public override bool Add(object key, object value)
        {
            // Creating an event.
            CollectionHandlerEventArgs args = new CollectionHandlerEventArgs(Name, "Object is added", value as State);
            CollectionCountChanged(Name, args);

            return base.Add(key, value);
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

                // Creating an event.
                CollectionHandlerEventArgs args = new CollectionHandlerEventArgs(Name, "Object changed its value", Table[index].value as State);
                CollectionReferenceChanged(Name, args);
            }
        }

        // Count changed event.
        public event CollectionHandler CollectionCountChanged;

        // Object changed its value event.
        public event CollectionHandler CollectionReferenceChanged;

        // Constructor without parameters.
        public MyNewDictionary() : base() { }

        // Constructor with parameter.
        public MyNewDictionary(int capacity) : base(capacity) { }

        public MyNewDictionary(MyDictionary<K, T> myDictionary): base(myDictionary) { }

        public void OnCollectionCountChanged()
        {
            if (CollectionCountChanged != null)
                CollectionCountChanged();
        }
    }
}
