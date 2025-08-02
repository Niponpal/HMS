using HMS.Models;

namespace HMS.Repositorys
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetAllData();
        String AddData(Doctor doctor);
        Doctor GetById(int id);
        void UpdateData(Doctor doctor);
        string DeleteData(int id);
    }
}
