namespace Vidzy.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Vidzy.VidzyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Vidzy.VidzyContext context)
        {
            var tag1 = context.Tags.Single(t => t.Name == "Top");
            var tag2 = context.Tags.Single(t => t.Name == "Shlop");
            var tag3 = context.Tags.Single(t => t.Name == "Fop");
            var tag4 = context.Tags.Single(t => t.Name == "Dop");
            var tag5 = context.Tags.Single(t => t.Name == "Pop");
            var tag6 = context.Tags.Single(t => t.Name == "Chop");
            var tag7 = context.Tags.Single(t => t.Name == "Stop");

            var video1 = context.Videos.Single(t => t.Name == "Rock");
            var video2 = context.Videos.Single(t => t.Name == "Paper");
            var video3 = context.Videos.Single(t => t.Name == "Scissors");
            var video4 = context.Videos.Single(t => t.Name == "MrBeast");
            var video5 = context.Videos.Single(t => t.Name == "MrBest");
            var video6 = context.Videos.Single(t => t.Name == "Jingle Fest");
            var video7 = context.Videos.Single(t => t.Name == "Single Text");

            var genre1 = context.Genres.Single(t => t.Name == "Comedy");
            var genre2 = context.Genres.Single(t => t.Name == "Action");
            var genre3 = context.Genres.Single(t => t.Name == "Horror");
            var genre4 = context.Genres.Single(t => t.Name == "Thriller");
            var genre5 = context.Genres.Single(t => t.Name == "Family");
            var genre6 = context.Genres.Single(t => t.Name == "Romance");
            var genre7 = context.Genres.Single(t => t.Name == "Drama");

            video1.Genre = genre1;
            video2.Genre = genre2;
            video3.Genre = genre3;
            video4.Genre = genre4;
            video5.Genre = genre5;
            video6.Genre = genre7;
            video7.Genre = genre7;

            video1.Tags = new List<Tag>
            {
                tag1,
                tag2,
                tag5,
                tag7
            };
            video2.Tags = new List<Tag>
            {
                tag3,
                tag4,
                tag6,
                tag1
            };
            video3.Tags = new List<Tag>
            {
                tag2,
                tag5,
                tag6,
                tag7
            };
            video4.Tags = new List<Tag>
            {
                tag3,
                tag4,
                tag1,
                tag6
            };
            video5.Tags = new List<Tag>
            {
                tag2,
                tag5,
                tag7,
                tag1
            };
            video6.Tags = new List<Tag>
            {
                tag3,
                tag4,
                tag6,
                tag7
            };
            video7.Tags = new List<Tag>
            {
                tag1,
                tag2,
                tag5,
                tag3
            };

            context.SaveChanges();
        }
    }
}
