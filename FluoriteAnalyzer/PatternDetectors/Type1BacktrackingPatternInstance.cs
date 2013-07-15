﻿using FluoriteAnalyzer.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluoriteAnalyzer.PatternDetectors
{
    class Type1BacktrackingPatternInstance : BacktrackingPatternInstance
    {
        public Type1BacktrackingPatternInstance(Event insert, Event delete, string description)
            : base(insert, 2, description)
        {
            this.Insert = insert;
            this.Delete = delete;

            AddInvolvingEvent("Insert", insert.ID);
            AddInvolvingEvent("Delete", delete.ID);
        }

        public Event Insert { get; set; }
        public Event Delete { get; set; }

        public override BacktrackingPatternInstance.BacktrackingType Type
        {
            get { return BacktrackingType.TYPE1; }
        }
    }
}