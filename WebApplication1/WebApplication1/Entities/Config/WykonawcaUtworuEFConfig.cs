using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_10.Entities.Config;

public class WykonawcaUtworuEFConfig : IEntityTypeConfiguration<WykonawcaUtworu>
{
    public void Configure(EntityTypeBuilder<WykonawcaUtworu> builder)
    {
        builder.HasKey(e => new { e.IdMuzyk, e.IdUtwor });
        builder.HasOne(e => e.Muzyk).WithMany(m => m.WykonawcaUtworow).HasForeignKey(e => e.IdMuzyk);
        builder.HasOne(e => e.Utwor).WithMany(u => u.WykonawcaUtworow).HasForeignKey(e => e.IdUtwor);
        builder.ToTable("WykonawcaUtworu");
    }
}
