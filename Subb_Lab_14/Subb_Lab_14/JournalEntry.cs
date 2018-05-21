using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subb_Lab_14
{
    class JournalEntry
    {
        // Name of the changed collection.
        public string Name { get; set; }

        // Type of change.
        public string ChangeType { get; set; }

        // Information about the object.
        public string ObjInfo { get; set; }

        // Constructor.
        public JournalEntry(string name, string changeType, string objInfo)
        {
            this.Name = name;
            this.ChangeType = changeType;
            this.ObjInfo = objInfo;
        }

        public override string ToString()
        {
            return "Name: " + Name + "\nType of change: " + ChangeType + "\n Object: " + ObjInfo;
        }
    }
}
