using HMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HMS.Repositorys
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetAllData();
        String AddData(Doctor doctor);
        Doctor GetById(int id);
        void UpdateData(Doctor doctor);
        string DeleteData(int id);

        IEnumerable<SelectListItem> Dropdown();
    }
}
