﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluoriteAnalyzer.Events;

namespace FluoriteAnalyzer.PatternDetectors
{
    [Serializable]
    class PatternInstance
    {
        public PatternInstance(Event primaryEvent, int patternLength, string description)
        {
            PrimaryEvent = primaryEvent;
            PatternLength = patternLength;
            Description = description;

            _involvingEvents = new List<Tuple<string, int>>();
        }

        public Event PrimaryEvent { get; private set; }
        public int PatternLength { get; private set; }
        public string Description { get; private set; }

        public virtual string CSVLine
        {
            get
            {
                return string.Empty;
            }
        }

        private List<Tuple<string, int>> _involvingEvents;

        public override string ToString()
        {
            return Description;
        }

        public void AddInvolvingEvent(string description, int id)
        {
            _involvingEvents.Add(Tuple.Create(description, id));
        }

        public IEnumerable<Tuple<string, int>> GetInvolvingEvents()
        {
            if (_involvingEvents.Count == 0)
            {
                if (PrimaryEvent != null)
                {
                    return new Tuple<string, int>[] { Tuple.Create("Primary Event", PrimaryEvent.ID) };
                }
                else
                {
                    return Enumerable.Empty<Tuple<string, int>>();
                }
            }
            else
            {
                return _involvingEvents;
            }
        }

        public virtual void CopyToClipboard()
        {
            // Do nothing here.
        }
    }
}
