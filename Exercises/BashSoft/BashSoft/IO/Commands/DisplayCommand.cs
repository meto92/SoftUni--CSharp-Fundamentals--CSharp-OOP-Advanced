using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using BashSoft.Attributes;
using BashSoft.Contracts;

namespace BashSoft.IO.Commands
{
    [Alias("display")]
    public class DisplayCommand : Command, IExecutable
    {
        [Inject]
        private IDatabase repository;

        public DisplayCommand(Match match)
            : base(match)
        { }

        private IComparer<T> GetComparer<T>(string orderType) where T : IComparable<T>
        {
            Comparer<T> comparer = Comparer<T>.Create((x, y) => x.CompareTo(y));

            if (string.Equals(orderType, "descending", StringComparison.OrdinalIgnoreCase))
            {
                comparer = Comparer<T>.Create((x, y) => y.CompareTo(x));
            }

            return comparer;
        }

        public override void Execute()
        {
            string entityToDisplay = base.Match.Groups[2].Value;
            string orderType = base.Match.Groups[3].Value;

            string result = null;

            if (string.Equals(entityToDisplay, "students"))
            {
                result = this.repository.GetAllStudentsSorted(this.GetComparer<IStudent>(orderType)).JoinWith(Environment.NewLine);
            }
            else if (string.Equals(entityToDisplay, "courses"))
            {
                result = this.repository.GetAllCoursesSorted(this.GetComparer<ICourse>(orderType)).JoinWith(Environment.NewLine);
            }

            OutputWriter.WriteMessageOnNewLine(result);
        }
    }
}