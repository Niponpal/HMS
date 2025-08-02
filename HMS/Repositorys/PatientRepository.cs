using HMS.Data;
using HMS.Models;

namespace HMS.Repositorys
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public string AddData(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
            return "Data Added Sucessful";
        }

        public string DeleteData(int id)
        {
            var data = _context.Patients.Find(id);
            if (data == null)
            {
                return "Not Found";
            }
            _context.Patients.Remove(data);
            _context.SaveChanges();
            return "Deleted Sucessful";
        }

        public IEnumerable<Patient> GatAllData()
        {
            var data = _context.Patients.ToList();
            return data;
        }

        public Patient GetById(int id)
        {
            var data = _context.Patients.Find(id);
            return data;
        }

        public void Update(Patient patient)
        {
            _context.Patients.Find(patient.Id);
            _context.SaveChanges();
        }
    }
}
