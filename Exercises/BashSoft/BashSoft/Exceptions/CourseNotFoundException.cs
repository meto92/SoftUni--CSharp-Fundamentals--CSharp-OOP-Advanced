using System;

public class CourseNotFoundException : Exception
{
    private const string NotEnrolledInCourse = "Student {0} must be enrolled in {1} before you set his mark.";

    public CourseNotFoundException(string message)
        : base(message)
    { }

    public CourseNotFoundException(string username, string courseName)
        : base(string.Format(NotEnrolledInCourse, username, courseName))
    { }
}