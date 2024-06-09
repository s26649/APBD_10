using APBD_10.Entities;
using APBD_10.RequestModels;

namespace APBD_10.Services;

public interface IMuzykService
{
    bool AddMuzyk(MuzykRequest request);
    Muzyk GetMuzyk(int id);
}
