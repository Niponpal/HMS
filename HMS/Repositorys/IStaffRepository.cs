using HMS.Models;

namespace HMS.Repositorys
{
    public interface IStaffRepository
    {
        IEnumerable<Staff> GetAllData();
        String AddData(Staff staff);
        Staff GetById(int id);
        void UpdateData(Staff staff);
        String DeleteData(int id);
    }
}
