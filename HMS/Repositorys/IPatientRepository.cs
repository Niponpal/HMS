using HMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HMS.Repositorys
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GatAllData();
        string AddData(Patient patient);
        Patient GetById(int id);
        void Update(Patient patient);
        String DeleteData(int id);
        IEnumerable<SelectListItem> Dropdown();
        IEnumerable<SelectListItem> DropdownMedical();
    }
}
