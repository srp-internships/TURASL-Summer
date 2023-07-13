

using System;
using System.Data.Entity;
using System.Linq;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new VidzyContext();

            var actionMovies = context.Videos
                .Where(v => v.Genre.Name == "Action")
                .OrderBy(v => v.Name);

            var goldDramas = context.Videos
                .Where(v => v.Classification == (Classification)2 && v.Genre.Name == "Drama")
                .OrderBy(v => v.ReleaseDate);

            var moviesGenres = context.Videos
                .Select(v => new
                {
                    MovieName = v.Name,
                    Genre = v.Genre.Name
                });

            var classificationMovies = context.Videos
                .GroupBy(v => v.Classification);

            var classificationMoviesCount = context.Videos
                .GroupBy(v => v.Classification)
                .OrderBy(g => g.Key);

            var genreMoviesCount = context.Videos
                .GroupBy(v => v.Genre)
                .OrderByDescending(g => g.Count());


            foreach(var item in actionMovies)
            {
                Console.WriteLine(item.Name);
            }

            foreach(var item in goldDramas)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine();

            foreach (var item in moviesGenres)
            {
                Console.WriteLine(item.MovieName + " - " + item.Genre);
            }

            Console.WriteLine();

            foreach (var g in classificationMovies)
            {
                Console.WriteLine(g.Key.ToString() + ':');

                foreach(var item in g)
                {
                    Console.WriteLine('\t' + item.Name);
                }
            }

            Console.WriteLine();

            foreach (var g in classificationMoviesCount)
            {
                Console.WriteLine(g.Key + " - (" + g.Count() + ')');
            }

            Console.WriteLine();

            foreach (var g in genreMoviesCount)
            {
                Console.WriteLine(g.Key.Name + " - (" + g.Count() + ')');
            }
        }
    }
}
