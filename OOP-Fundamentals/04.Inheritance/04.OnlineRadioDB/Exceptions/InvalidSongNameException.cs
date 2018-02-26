using System;
using System.Collections.Generic;
using System.Text;

public class InvalidSongNameException:InvalidSongException
{
    private const string defaultMessage = "Song name should be between 3 and 30 symbols.";

    public InvalidSongNameException():base(defaultMessage)
    {
    }
}

