using System;
using System.Linq;
using System.Xml.Linq;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            AddVideoToDb("Breaking Bad", "Action", new DateTime(1900, 1, 1), (Classification)1);
            AddTagsToDb("classics", "drama");
            AddTagsToTheVideo(1, "classics", "drama", "comedy");
            RemoveTagFromTheVideo(1, "comedy");
            RemoveVideoFromDb(1);
            RemoveGenreFromDb(2);
        }


        public static void AddVideoToDb(string name, string genre, DateTime releaseDate, Classification classification)
        {
            byte genreId = 0;
            switch (genre)
            {
                case "Comedy":
                    genreId = 1;
                    break;
                case "Action":
                    genreId = 2;
                    break;
                case "Horror":
                    genreId = 3;
                    break;
                case "Thriller":
                    genreId = 4;
                    break;
                case "Family":
                    genreId = 5;
                    break;
                case "Romance":
                    genreId = 6;
                    break;
                case "Drama":
                    genreId = 7;
                    break;
            }

            using (var context = new VidzyContext())
            {
                var video = context.Videos.FirstOrDefault(v => v.Name.Equals(name));

                if (video == null)
                {
                    video = new Video
                    {
                        Name = name,
                        GenreId = genreId,
                        ReleaseDate = releaseDate,
                        Classification = classification
                    };

                    context.Videos.Add(video);

                    context.SaveChanges();
                }
            }
        }

        public static void AddTagsToDb(params string[] names)
        {
            using (var context = new VidzyContext())
            {
                foreach (var name in names)
                {
                    var tagThere = context.Tags.FirstOrDefault(t => t.Name.Equals(name));
                    if (tagThere == null)
                    {
                        var tag = new Tag
                        {
                            Name = name
                        };
                        context.Tags.Add(tag);
                    }
                }
                context.SaveChanges();
            }
        }

        public static void AddTagsToTheVideo(int id, params string[] tags)
        {
            using (var context = new VidzyContext())
            {
                var video = context.Videos.Find(id);

                if (video != null)
                {
                    foreach (var tagName in tags)
                    {
                        var tagInDb = context.Tags.FirstOrDefault(t => t.Name.Equals(tagName));
                        if (tagInDb == null)
                            AddTagsToDb(tagName);

                        var tagThere = video.Tags.FirstOrDefault(t => t.Name.Equals(tagName));

                        if (tagThere == null)
                        {
                            video.Tags.Add(tagInDb);
                        }
                    }

                    context.SaveChanges();
                }
            }
        }

        public static void RemoveTagFromTheVideo(int id, params string[] tags)
        {
            using (var context = new VidzyContext())
            {
                var video = context.Videos.Find(id);

                if (video != null)
                {
                    foreach (var tagName in tags)
                    {
                        var tagInDb = context.Tags.FirstOrDefault(t => t.Name.Equals(tagName));
                        var tagIsInVid = video.Tags.Contains(tagInDb);
                        if (tagIsInVid)
                        {
                            video.Tags.Remove(tagInDb);
                        }
                    }
                    context.SaveChanges();
                }
            }
        }

        public static void RemoveVideoFromDb(int id)
        {
            using (var context = new VidzyContext())
            {
                var video = context.Videos.Find(id);

                if (video != null)
                {
                    context.Videos.Remove(video);
                    context.SaveChanges();
                }
            }
        }

        public static void RemoveGenreFromDb(byte id)
        {
            using (var context = new VidzyContext())
            {
                var genre = context.Genres.Find(id);

                if (genre != null)
                {
                    context.Videos.RemoveRange(context.Videos.Where(v => v.GenreId.Equals(id)));
                    context.Genres.Remove(genre);
                    context.SaveChanges();
                }
            }
        }
    }


}
