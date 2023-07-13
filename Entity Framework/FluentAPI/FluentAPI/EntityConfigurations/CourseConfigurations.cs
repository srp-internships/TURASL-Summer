using DataAnnotations;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI.EntityConfigurations
{
    public class CourseConfigurations : EntityTypeConfiguration<Course>
    {
        public CourseConfigurations()
        {
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            Property(c => c.Description)
                    .IsRequired()
                    .HasMaxLength(2000);

            HasRequired(c => c.Author)
                    .WithMany(a => a.Courses)
                    .HasForeignKey(c => c.AuthorId)
                    .WillCascadeOnDelete(false);

            HasMany(a => a.Tags)
                    .WithMany(t => t.Courses)
                    .Map(m =>
                    {
                        m.ToTable("CourseTags");
                        m.MapLeftKey("CourseId");
                        m.MapRightKey("TadId");
                    });

            HasRequired(c => c.Cover)
                    .WithRequiredPrincipal(c => c.Course);
        }
    }
}
