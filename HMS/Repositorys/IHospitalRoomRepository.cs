using HMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HMS.Repositorys
{
    public interface IHospitalRoomRepository
    {
        IEnumerable<HospitalRoom> GetAllData();
        string AddData(HospitalRoom hospitalRoom);
        HospitalRoom GetById(int id);
        void UpdateData(HospitalRoom hospitalRoom);
        string DeleteData(int  id);
        IEnumerable<SelectListItem> Dropdown();
    }
}
