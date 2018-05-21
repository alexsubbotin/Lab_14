using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Subb_Lab_14
{
    // My collection – dictionary (hash-table).
    class MyDictionary<K, T> : IEnumerable 
    {
        // Array of the DicPoint elements (hash-table).
        DicPoint<K, T>[] table;
        public DicPoint<K, T>[] Table { get; set; }

        // The hash-table capacity.
        int capacity;
        public int Capacity
        {
            get
            {
                return capacity;
            }
            set
            {
                if (value < 0)
                {
                    //Console.WriteLine("Capacity can not be negative!");
                    capacity = 0;
                    throw new NegativeValueException("Capacity can not be negative!");
                }
                else
                    capacity = value;
            }
        }

        // The hash-table count.
        int count;
        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                if (value < 0)
                {
                    //Console.WriteLine("Count can not be negative!");
                    count = 0;
                    throw new NegativeValueException("Count can not be negative!");
                }
                else
                    count = value;
            }
        }

        // All the keys in a dictionary.
        K[] keys;
        public K[] Keys
        {
            get
            {
                return keys;
            }
            set
            {
                if (value != null)
                {
                    keys = new K[value.Length];
                    for (int i = 0; i < value.Length; i++)
                        keys[i] = value[i];
                }
                else
                    keys = value;
            }
        }

        // All the values in a dictionary (object because it is actually AbstrState).
        T[] values;
        public T[] Values
        {
            get
            {
                return values;
            }
            set
            {
                if (value != null)
                {
                    values = new T[value.Length];
                    for (int i = 0; i < value.Length; i++)
                        values[i] = value[i];
                }
                else
                    values = value;
            }
        }


        // Constructor without parameters.
        public MyDictionary()
        {
            // Initital capacity is 100.
            Table = new DicPoint<K, T>[100];
            for (int i = 0; i < Table.Length; i++)
                Table[i] = new DicPoint<K, T>();
            Capacity = 100;
            Count = 0;
            Keys = null;
            Values = null;
        }
        // Constructor with a capacity parameter.
        public MyDictionary(int capacity)
        {
            Table = new DicPoint<K, T>[capacity];
            for (int i = 0; i < Table.Length; i++)
                Table[i] = new DicPoint<K, T>();
            this.Capacity = capacity;
            Count = 0;
            Keys = null;
            Values = null;
        }
        // Constructor with a MyDictionary object parameter.
        public MyDictionary(MyDictionary<K, T> dic)
        {
            Table = new DicPoint<K, T>[dic.Table.Length];
            for (int i = 0; i < dic.Table.Length; i++)
            {
                this.Table[i] = dic.Table[i];
            }

            this.Keys = new K[dic.Keys.Length];
            for (int i = 0; i < dic.Keys.Length; i++)
            {
                this.Keys[i] = dic.Keys[i];
            }

            this.Values = new T[dic.Values.Length];
            for (int i = 0; i < dic.Values.Length; i++)
            {
                this.Values[i] = dic.Values[i];
            }

            Capacity = dic.capacity;
            Count = dic.count;
        }

        // Checks whether there is such key (parameter) or not.
        public bool ContainsKey(object key)
        {
            bool contains = false;
            if (Keys != null)
            {
                for (int i = 0; i < this.Keys.Length; i++)
                {
                    if (this.Keys[i].Equals((K)key))
                    {
                        contains = true;
                        break;
                    }
                }
            }

            return contains;
        }

        // Checks whether there is such value (parameter) or not.
        public bool ContainsValue(object value)
        {
            bool contains = false;
            if (Values != null)
            {
                for (int i = 0; i < this.Values.Length; i++)
                {
                    if (this.Values[i].Equals((T)value))
                    {
                        contains = true;
                        break;
                    }
                }
            }

            return contains;
        }

        // Adds an element to the dictionary.
        public virtual bool Add(object key, object value)
        {
            // Creating an object with wanted key and value.
            DicPoint<K, T> dicPointBuffer = new DicPoint<K, T>((K)key, (T)value);

            // Getting index.
            int index = GetIndex(key);

            // If there are no objects with this index.
            if (Table[index] == null || Table[index].value == null)
            {
                DicPoint<K, T> buf = new DicPoint<K, T>((K)key, (T)value);
                Table[index] = buf;
            }
            else
            {
                // The first object in the list of this index.
                DicPoint<K, T> current = Table[index];

                // If there is the same object.
                if (current.Equals(dicPointBuffer))
                    return false;

                // Finding the end of the list or the same object.
                while (current.next != null)
                {
                    if (current.next.Equals(dicPointBuffer))
                        return false;
                    current = current.next;
                }

                // Adding the element to the table.
                current.next = dicPointBuffer;
            }

            // Adding the key and the value to the arrays and increasing the count.
            AddKey((K)key);
            AddValue((T)value);
            Count++;

            return true;
        }

        // Getting the index of the adding element.
        public int GetIndex(object key)
        {
            // Necessary constant (random 0 < A < 1).
            double A = 0.12837912;

            // Creating the index.
            int index = (int)Math.Truncate(Capacity * (((int)key * A) % 1));

            return index;
        }

        // Additional function to add an element to the array of keys.
        public void AddKey(K key)
        {
            K[] buf;
            if (Keys != null)
                buf = new K[Keys.Length + 1];
            else
                buf = new K[1];

            for (int i = 0; i < buf.Length - 1; i++)
            {
                buf[i] = Keys[i];
            }
            buf[buf.Length - 1] = key;

            Keys = buf;
        }

        // Additional function to add an element to the array of values.
        public void AddValue(T value)
        {
            T[] buf;
            if (Values != null)
                buf = new T[Values.Length + 1];
            else
                buf = new T[1];

            for (int i = 0; i < buf.Length - 1; i++)
            {
                buf[i] = Values[i];
            }
            buf[buf.Length - 1] = value;

            Values = buf;
        }

        // Clear the dictionary.
        public void Clear()
        {
            Table = new DicPoint<K, T>[100];
            Capacity = 100;
            Count = 0;
            Keys = null;
            Values = null;
        }

        // Clone the dictionary.
        public MyDictionary<K, T> Clone()
        {
            MyDictionary<K, T> buf = this;
            return buf;
        }

        // Removing an object with the wanted value (parameter).
        public bool Remove(object value)
        {
            // Index of the element.
            int ind = -1;

            if (Values != null)
            {
                // Getting the index.
                for (int i = 0; i < Values.Length; i++)
                {
                    if (Values[i].Equals((T)value))
                    {
                        ind = i;
                        break;
                    }
                }
            }

            // If the elemet exists.
            if (ind > -1)
            {
                // Getting the key of the object.
                object key = Keys[ind];
                // Getting the index og the object.
                int index = GetIndex(key);

                // Deleting it from the Keys.
                DelFromKeys(ind);
                // Deleting it from the Values.
                DelFromValues(ind);

                DicPoint<K, T> current = Table[index];

                // IF it's the first in the list.
                if (current.value.Equals((T)value))
                {
                    Table[index] = null;
                    Count--;
                }
                else
                {
                    // Looking till the end of the list.
                    while (current.next != null)
                    {
                        // If found.
                        if (current.next.value.Equals((T)value))
                        {
                            current.next = current.next.next;
                            Count--;
                            return true;
                        }

                        current = current.next;
                    }
                }

                return true;
            }
            else
                return false;
        }

        // Deleting an element from the Keys.
        public void DelFromKeys(int index)
        {
            K[] bufKeys = new K[Keys.Length - 1];

            for (int i = 0; i < index; i++)
                bufKeys[i] = Keys[i];

            for (int i = index + 1; i < Keys.Length; i++)
                bufKeys[i - 1] = Keys[i];

            Keys = bufKeys;
        }

        // Deleting an element from the Values.
        public void DelFromValues(int index)
        {
            T[] bufValues = new T[Values.Length - 1];

            for (int i = 0; i < index; i++)
                bufValues[i] = Values[i];

            for (int i = index + 1; i < Values.Length; i++)
                bufValues[i - 1] = Values[i];

            Values = bufValues;
        }

        // Redefinition of the GetEnumerator method.
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Capacity; i++)
            {
                DicPoint<K, T> curr = Table[i];

                while (curr != null)
                {
                    yield return curr;
                    curr = curr.next;
                }
            }
        }
    }
}
