using MusicXConsoleApp.Data;
using System;
using System.Linq;

namespace MusicXConsoleApp
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new MusicXDbContext();

            Console.WriteLine(db.Songs.Count(s=>s.SongArtists.Any(sa=>sa.Artist.Name=="Eminem")));
        }
    }
}
