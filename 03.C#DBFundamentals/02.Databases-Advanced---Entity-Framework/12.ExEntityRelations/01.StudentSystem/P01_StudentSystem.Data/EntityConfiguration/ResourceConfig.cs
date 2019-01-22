using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data.EntityConfiguration
{
  public  class ResourceConfig:IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode();

            builder.Property(x => x.Url)
                .IsRequired()
                .IsUnicode(false);
        }
    }
}
