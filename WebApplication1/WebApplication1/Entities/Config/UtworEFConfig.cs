using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_10.Entities.Config;

public class UtworEFConfig : IEntityTypeConfiguration<Utwor>
{
    public void Configure(EntityTypeBuilder<Utwor> builder)
    {
        builder.HasKey(e => e.IdUtwor).HasName("Utwor_pk");
        builder.Property(e => e.IdUtwor).UseIdentityColumn();
        builder.Property(e => e.NazwaUtworu).IsRequired().HasMaxLength(30);
        builder.Property(e => e.CzasTrwania).IsRequired();
        builder.ToTable("Utwor");
    }
}
