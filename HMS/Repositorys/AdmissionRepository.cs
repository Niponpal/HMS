using HMS.Data;
using HMS.Models;

namespace HMS.Repositorys
{
    public class AdmissionRepository : IAdmissionRepository
    {
        private readonly ApplicationDbContext _context;
        public AdmissionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public string AddData(Admission admission)
        {
           _context.Admissions.Add(admission);
            _context.SaveChanges();
            return "Added Succesful";
        }

        public string DeleteData(int id)
        {
            var data = _context.Admissions.Find(id);
            if (data != null) 
            {
                return "NotFound";
            }
            _context.Admissions.Remove(data);
            _context.SaveChanges();
            return "Delete Data Sucecesful";
        }

        public IEnumerable<Admission> GetAllData()
        {
            var data = _context.Admissions.ToList();
            return data;

        }

        public Admission GetById(int id)
        {
            var data = _context.Admissions.Find(id);
            return data;
        }

        public void UpdateData(Admission admission)
        {
            _context.Admissions.Find(admission.Id);
            _context.SaveChanges();

        }

    }
}
