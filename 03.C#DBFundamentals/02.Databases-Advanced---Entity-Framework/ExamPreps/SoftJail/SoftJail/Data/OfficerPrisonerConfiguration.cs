namespace SoftJail.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class OfficerPrisonerConfiguration : IEntityTypeConfiguration<OfficerPrisoner>
    {
        public void Configure(EntityTypeBuilder<OfficerPrisoner> builder)
        {
            builder
                .HasKey(op => new { op.OfficerId, op.PrisonerId });
        }
    }
}