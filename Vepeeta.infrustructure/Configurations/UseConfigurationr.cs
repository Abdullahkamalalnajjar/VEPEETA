using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vepeeta.Data.Entity.Identity;

namespace Vepeeta.infrustructure.Configurations
{

    public class UseConfigurationr : IEntityTypeConfiguration<PetOwner>
    {
        public void Configure(EntityTypeBuilder<PetOwner> builder)
        {
            builder.Property(s => s.Weight)
                .HasColumnType("decimal(18,2)");
            builder.Property(s => s.PhoneNumber).IsRequired(false);
            builder.Property(s => s.sensitivity).IsRequired(false);
        }
    }
}

