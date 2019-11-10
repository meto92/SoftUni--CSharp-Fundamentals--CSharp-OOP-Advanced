using System;
using System.Linq;
using System.Collections.Generic;

using BashSoft.IO;
using BashSoft.Contracts;

namespace BashSoft.Repository
{
    public class RepositoryFilter : IDataFilter
    {
        private void FilterAndTake(Dictionary<string, double> studentsWithMarks, Predicate<double> givenFilter, int studentsToTake)
        {
            foreach (KeyValuePair<string, double> pointsByUsername
                in studentsWithMarks
                    .Where(p => givenFilter(p.Value))
                    .Take(studentsToTake))
            {
                OutputWriter.PrintStudent(pointsByUsername);
            }
        }

        public void FilterAndTake(Dictionary<string, double> studentsWithMarks, string wantedFilter, int studentsToTake)
        {
            switch (wantedFilter)
            {
                case "excellent":
                    this.FilterAndTake(studentsWithMarks, x => x >= 5.0, studentsToTake);
                    break;
                case "average":
                    this.FilterAndTake(studentsWithMarks, x => x >= 3.5 && x < 5.0, studentsToTake);
                    break;
                case "poor":
                    this.FilterAndTake(studentsWithMarks, x => x < 3.5, studentsToTake);
                    break;
            }
        }
    } 
}