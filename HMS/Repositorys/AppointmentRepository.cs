using HMS.Data;
using HMS.Models;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace HMS.Repositorys
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;
        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public string AddData(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            return "Added Data SucessFully";
        }

        public string DeleteData(int id)
        {
            var data = _context.Appointments.Find(id);
            if (data == null) 
            {
                return "Null";
            }
            _context.Appointments.Remove(data);
            _context.SaveChanges();
            return "Delete Successfull";
        }

        public IEnumerable<Appointment> GetAllData()
        {
            var data = _context.Appointments.ToList();
            return data;
        }

        public Appointment GetById(int id)
        {
            var data = _context.Appointments.Find(id);
            return data;
        }

        public void UpdateData(Appointment appointment)
        {
            _context.Appointments.Find(appointment.Id);
            _context.SaveChanges();
        }
    }
}
