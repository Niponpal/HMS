using HMS.Models;

namespace HMS.Repositorys
{
    public interface IMedicineRepository
    {
        IEnumerable<Medicine> GetAllData();
        string AddData(Medicine medicine);
        Medicine GetById(int id);
        void UpdateData(Medicine medicine);
        string DeleteData(int id);
        
    }
}
