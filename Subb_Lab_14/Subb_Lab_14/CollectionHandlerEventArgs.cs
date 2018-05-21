using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subb_Lab_14
{
    class CollectionHandlerEventArgs
    {
        // Collection name.
        public string Name { get; set; }

        // Type of change.
        public string ChangeType { get; set; }
    }
}
