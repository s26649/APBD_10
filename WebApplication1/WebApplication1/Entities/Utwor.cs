namespace APBD_10.Entities;

public class Utwor
{
    public int IdUtwor { get; set; }
    public string NazwaUtworu { get; set; }
    public float CzasTrwania { get; set; }
    public int? IdAlbum { get; set; }
    public virtual ICollection<WykonawcaUtworu> WykonawcaUtworow { get; set; } = new List<WykonawcaUtworu>();
}
