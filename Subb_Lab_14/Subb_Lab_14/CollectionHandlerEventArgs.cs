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

        // Link to the changed object.
        public State Obj { get; set; }

        // Constructor.
        public CollectionHandlerEventArgs(string name, string changeType, State obj)
        {
            this.Name = name;
            this.ChangeType = changeType;
            this.Obj = obj;
        }

        // To string method.
        public override string ToString()
        {
            return "Name: " + Name + "\nType of change: " + ChangeType + "\n Object: " + Obj.ToString();
        }
    }
}
