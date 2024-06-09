using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_10.Entities.Config;

public class WytworniaEFConfig : IEntityTypeConfiguration<Wytwornia>
{
    public void Configure(EntityTypeBuilder<Wytwornia> builder)
    {
        builder.HasKey(e => e.IdWytwornia).HasName("Wytwornia_pk");
        builder.Property(e => e.IdWytwornia).UseIdentityColumn();
        builder.Property(e => e.Nazwa).IsRequired().HasMaxLength(50);
        builder.ToTable("Wytwornia");
    }
}
