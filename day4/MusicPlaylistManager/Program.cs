using System;
using System.Collections.Generic;

class MusicPlaylistManager
{
    static void Main()
    {
        // LinkedList to manage playlist songs
        LinkedList<string> playlist = new LinkedList<string>();

        // SortedList to store songs sorted by rating
        SortedList<int, string> songsByRating = new SortedList<int, string>();

        // SortedDictionary to map artist -> song
        SortedDictionary<string, string> artistSongs = new SortedDictionary<string, string>();

        // Adding songs to LinkedList
        playlist.AddLast("Vaathi Coming");
        playlist.AddLast("Arabic Kuthu");
        playlist.AddLast("Tum Tum");

        // Insert a song at the beginning
        playlist.AddFirst("Why This Kolaveri Di");

        // Remove a song
        playlist.Remove("Tum Tum");

        // Adding songs with ratings
        songsByRating.Add(5, "Vaathi Coming");
        songsByRating.Add(4, "Arabic Kuthu");
        songsByRating.Add(3, "Why This Kolaveri Di");

        // Adding Tamil artist and song mapping
        artistSongs.Add("A.R. Rahman", "Mukkala Mukabula");
        artistSongs.Add("Anirudh Ravichander", "Why This Kolaveri Di");
        artistSongs.Add("Harris Jayaraj", "Vaseegara");

        // Display playlist songs
        Console.WriteLine("Playlist Songs:");
        foreach (string song in playlist)
        {
            Console.WriteLine(song);
        }

        // Display songs sorted by rating
        Console.WriteLine("\nSongs Sorted by Rating:");
        foreach (KeyValuePair<int, string> item in songsByRating)
        {
            Console.WriteLine("Rating: " + item.Key + " - Song: " + item.Value);
        }

        // Display artist-wise songs in sorted order
        Console.WriteLine("\nArtist-wise Songs (Sorted by Artist Name):");
        foreach (KeyValuePair<string, string> item in artistSongs)
        {
            Console.WriteLine("Artist: " + item.Key + " - Song: " + item.Value);
        }
    }
}
