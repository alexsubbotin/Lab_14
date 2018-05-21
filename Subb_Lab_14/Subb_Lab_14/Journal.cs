﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subb_Lab_14
{
    class Journal
    {
        // This list of changes.
        private List<JournalEntry> list;

        // Count changed event handler.
        public void CollectionCountChanged(object source, CollectionHandlerEventArgs args)
        {
            // Creating an object with change info.
            JournalEntry journalEntry = new JournalEntry(args.Name, args.ChangeType, args.Obj.ToString());

            list.Add(journalEntry);
        }

        // Onject changed its value event handler.
        public void CollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
        {
            // Creating an object with change info.
            JournalEntry journalEntry = new JournalEntry(args.Name, args.ChangeType, args.Obj.ToString());

            list.Add(journalEntry);
        }

        public override string ToString()
        {
            string s = "";

            foreach (JournalEntry j in list)
                s += j.Name + " " + j.ChangeType + " " + j.ObjInfo + "\n";

            return s;
        }
    }
}
