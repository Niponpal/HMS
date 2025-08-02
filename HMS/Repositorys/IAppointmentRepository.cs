using HMS.Models;

namespace HMS.Repositorys
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> GetAllData();
        string AddData(Appointment appointment);
        Appointment GetById(int id);
        void UpdateData(Appointment appointment); 
        string DeleteData(int id);
    }
}
