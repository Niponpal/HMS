using HMS.Models;

namespace HMS.Repositorys
{
    public interface IAdmissionRepository
    {
        IEnumerable<Admission> GetAllData();
        string AddData(Admission admission);
        Admission GetById(int id);
        void UpdateData(Admission admission);
        string DeleteData(int id);
        
    }
}
