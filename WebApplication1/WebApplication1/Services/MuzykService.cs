using APBD_10.Entities;
using APBD_10.RequestModels;
using Microsoft.EntityFrameworkCore;

namespace APBD_10.Services;

public class MuzykService : IMuzykService
{
    private readonly MusicDbContext _dbContext;

    public MuzykService(MusicDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool AddMuzyk(MuzykRequest request)
    {
        using var transaction = _dbContext.Database.BeginTransaction();
        try
        {
            Muzyk muzyk = new Muzyk
            {
                Imie = request.Imie,
                Nazwisko = request.Nazwisko,
                Pseudonim = request.Pseudonim
            };

            if (request.UtworId.HasValue)
            {
                var utwor = _dbContext.Utwory.Find(request.UtworId.Value);
                if (utwor == null)
                {
                    return false;
                }

                _dbContext.Muzycy.Add(muzyk);
                _dbContext.SaveChanges();

                var wykonawcaUtworu = new WykonawcaUtworu
                {
                    IdMuzyk = muzyk.IdMuzyk,
                    IdUtwor = request.UtworId.Value
                };
                _dbContext.WykonawcyUtworow.Add(wykonawcaUtworu);
            }
            else
            {
                _dbContext.Muzycy.Add(muzyk);
            }

            _dbContext.SaveChanges();
            transaction.Commit();
            return true;
        }
        catch (Exception)
        {
            transaction.Rollback();
            return false;
        }
    }

    public Muzyk GetMuzyk(int id)
    {
        return _dbContext.Muzycy.Include(m => m.WykonawcaUtworow)
            .ThenInclude(wu => wu.Utwor)
            .FirstOrDefault(m => m.IdMuzyk == id);
    }
}
