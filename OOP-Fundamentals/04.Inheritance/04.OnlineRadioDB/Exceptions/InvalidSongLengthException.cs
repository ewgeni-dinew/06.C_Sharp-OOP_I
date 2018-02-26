using System;
using System.Collections.Generic;
using System.Text;

public class InvalidSongLengthException:InvalidSongException
{
    private const string defaultMessage = "Invalid song length.";

    public InvalidSongLengthException():base(defaultMessage)
    {
    }
    public InvalidSongLengthException(string message):base(message)
    {
    }
}

