using System;
using System.Collections.Generic;
using System.Text;

public class InvalidSongException:ArgumentException
{
    private const string defaultMessage= "Invalid song.";

    public InvalidSongException():base(defaultMessage)
    {
    }
    public InvalidSongException(string message):base(message)
    {
    }
}

