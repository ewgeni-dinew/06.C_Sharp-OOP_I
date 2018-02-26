using System;
using System.Collections.Generic;
using System.Text;

public class InvalidArtistNameException:InvalidSongException
{
    private const string defaultMessage = "Artist name should be between 3 and 20 symbols.";

    public InvalidArtistNameException():base(defaultMessage)
    {
    }
}

