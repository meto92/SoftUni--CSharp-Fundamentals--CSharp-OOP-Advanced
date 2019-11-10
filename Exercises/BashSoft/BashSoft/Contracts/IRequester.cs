﻿using System.Collections.Generic;

namespace BashSoft.Contracts
{
    public interface IRequester
    {
        void GetStudentMarkInCourse(string courseName, string username);

        void GetStudentsByCourse(string courseName);

        ISimpleOrderedBag<ICourse> GetAllCoursesSorted(IComparer<ICourse> cmp);

        ISimpleOrderedBag<IStudent> GetAllStudentsSorted(IComparer<IStudent> cmp);
    }
}