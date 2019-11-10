using System;

class DataNotInitializedException : Exception
{
    public const string DataNotInitializedMessage = "The data structure must be initialized first in order to make any operations with it.";

    public DataNotInitializedException()
        : base(DataNotInitializedMessage)
    {
    }

    public DataNotInitializedException(string message)
        : base(message)
    {

    }
}