using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subb_Lab12
{
    // Class of the Hash-table elements.
    class DicPoint<K, T>
    {
        // Element's value.
        public T value;
        // Key
        public K key;
        // Next element with the same hash-code.
        public DicPoint<K, T> next;

        // Constructor without parameters
        public DicPoint()
        {
            value = default(T);
            key = default(K);
            next = null;
        }

        // Constructor with a T parameter.
        public DicPoint(K key, T ob)
        {
            value = ob;
            this.key = key;
            next = null;
        }

        // Redefinition of the Equals method.
        public override bool Equals(object obj)
        {
            DicPoint<K, T> buf = (DicPoint<K, T>)obj;

            if (value.Equals(buf.value) && key.Equals(buf.key))
                return true;
            else
                return false;
        }
    }
}
