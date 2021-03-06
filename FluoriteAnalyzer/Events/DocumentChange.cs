﻿using System.Xml;
using System;

namespace FluoriteAnalyzer.Events
{
    [Serializable]
    public class DocumentChange : Event
    {
        public DocumentChange(XmlElement element)
            : base(element)
        {
            Offset = int.Parse(GetPropertyValueFromDict("offset"));
            Length = int.Parse(GetPropertyValueFromDict("length"));
            DocumentLength = int.Parse(GetPropertyValueFromDict("docLength"));
            ActiveCodeLength = int.Parse(GetPropertyValueFromDict("docActiveCodeLength"));
            ExpressionCount = int.Parse(GetPropertyValueFromDict("docExpressionCount"));
            ASTNodeCount = int.Parse(GetPropertyValueFromDict("docASTNodeCount"));
        }

        public override EventType EventType
        {
            get { return EventType.DocumentChange; }
        }

        public int Offset { get; internal set; }
        public int Length { get; internal set; }

        public int DocumentLength { get; private set; }
        public int ActiveCodeLength { get; private set; }
        public int ExpressionCount { get; private set; }
        public int ASTNodeCount { get; private set; }
    }
}