using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        var inputSongCount = int.Parse(Console.ReadLine());
        var songList = new List<Song>();

        for (int i = 0; i < inputSongCount; i++)
        {
            try
            {
                var currentSong = ParseSongFromInput();
                Console.WriteLine("Song added.");

                songList.Add(currentSong);
            }
            catch (InvalidSongException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        var finalMinutes = songList.Select(s=>s.Minutes).Sum();
        var finalSeconds = songList.Select(s=>s.Seconds).Sum();
        var finalHours = 0;

        if (finalSeconds >= 60)
        {
            var temp = finalSeconds;
            finalSeconds %= 60;
            temp -= finalSeconds;
            finalMinutes += (temp / 60);
        }
        
        if (finalMinutes >= 60)
        {
            var temp = finalMinutes;
            finalMinutes %= 60;
            temp -= finalMinutes;
            finalHours += (temp / 60);
        }
        PrintData(songList, finalHours, finalMinutes, finalSeconds);
    }

    private static void PrintData(List<Song> songList, int finalHours, int finalMinutes, int finalSeconds)
    {
        Console.WriteLine($"Songs added: {songList.Count}");
        Console.WriteLine($"Playlist length: {finalHours}h {finalMinutes}m {finalSeconds}s");
    }

    private static Song ParseSongFromInput()
    {
        var input = Console.ReadLine()
            .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        var artist = input[0];
        var songName = input[1];
        var timeSpan = input[2].Split(new char[] {':'},StringSplitOptions.RemoveEmptyEntries);
        var minutes = int.Parse(timeSpan[0]);
        var seconds = int.Parse(timeSpan[1]);

        var song = new Song(artist,songName,minutes,seconds);

        return song;
    }
}

