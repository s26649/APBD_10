using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_10.Entities.Config;

public class AlbumEFConfig : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder.HasKey(e => e.IdAlbum).HasName("Album_pk");
        builder.Property(e => e.IdAlbum).UseIdentityColumn();
        builder.Property(e => e.NazwaAlbumu).IsRequired().HasMaxLength(30);
        builder.Property(e => e.DataWydania).IsRequired();
        builder.HasOne(e => e.Wytwornia).WithMany(w => w.Albumy).HasForeignKey(e => e.IdWytwornia);
        builder.ToTable("Album");
    }
}
