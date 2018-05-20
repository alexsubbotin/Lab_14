using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subb_Lab_13
{
    // Negative value exception class.
    class NegativeValueException:ApplicationException
    {
        public NegativeValueException() : base() { }
        public NegativeValueException(string str):base(str) { }
        public override string ToString()
        {
            return Message;
        }
    }
}
