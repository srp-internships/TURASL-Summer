using System;
using System.Data.Entity.ModelConfiguration;
using Vidzy;

namespace Vidzy.EntityConfigurations
{
    public class VideoConfigurations : EntityTypeConfiguration<Video>
    {
        public VideoConfigurations()
        {
            Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(255);

            Property(v => v.Classification)
                .IsRequired();

            HasRequired(v => v.Genre)
                .WithMany(g => g.Videos)
                .HasForeignKey(v => v.GenreId);

            HasMany(v => v.Tags)
                .WithMany(t => t.Videos)
                .Map(m =>
                {
                    m.ToTable("VideoTags");
                    m.MapLeftKey("TagId");
                    m.MapRightKey("VideoId");
                });
        }
    }
}
