using System;
using System.Collections.Generic;
using System.Text;

public class InvalidSongSecondsException:InvalidSongLengthException
{
    private const string defaultMessage = "Song seconds should be between 0 and 59.";

    public InvalidSongSecondsException():base(defaultMessage)
    {
    }
}

