using HMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HMS.Repositorys
{
    public interface ILabTestRepository
    {
        IEnumerable<LabTest> GetAllData();
        string AddData(LabTest labTest);
        LabTest GetById(int id);
        void UpdateData(LabTest labTest);
        string DeleteData(int id);
       
    }
}
