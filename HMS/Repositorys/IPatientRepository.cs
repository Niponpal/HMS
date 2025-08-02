using HMS.Models;

namespace HMS.Repositorys
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GatAllData();
        string AddData(Patient patient);
        Patient GetById(int id);
        void Update(Patient patient);
        String DeleteData(int id);
    }
}
