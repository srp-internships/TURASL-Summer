using System.Data.Entity.ModelConfiguration;

namespace Vidzy.EntityConfigurations
{
    public class GenreConfigurations : EntityTypeConfiguration<Genre>
    {
        public GenreConfigurations()
        {
            Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
