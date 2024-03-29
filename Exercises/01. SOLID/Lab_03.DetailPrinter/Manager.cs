﻿using System;
using System.Text;
using System.Collections.Generic;

namespace DetailPrinter
{
    public class Manager : Employee
    {
        public Manager(string name, ICollection<string> documents) 
            : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString());
            result.Append(string.Join(Environment.NewLine, this.Documents));

            return result.ToString().TrimEnd();
        }
    }
}