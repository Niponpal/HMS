using HMS.Data;
using HMS.Models;

namespace HMS.Repositorys
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly ApplicationDbContext _context;
       public MedicineRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public string AddData(Medicine medicine)
        {
            var data = _context.Medicines.Add(medicine);
            if (data == null) 
            {
                return "Notfond";
            }
            _context.SaveChanges();
            return "Data Added Sucessfully";
        }

        public string DeleteData(int id)
        {
           var data = _context.Medicines.Find(id);
            if (data == null)
            {
                return "NotFound";
            }
            _context.Medicines.Remove(data);
            _context.SaveChanges();
            return "Data Delete Sucessfully";
        }

        public IEnumerable<Medicine> GetAllData()
        {
            var data = _context.Medicines.ToList();
            return data;
        }

        public Medicine GetById(int id)
        {
            var data = _context.Medicines.Find(id);
            return data;
        }

        public void UpdateData(Medicine medicine)
        {
            _context.Medicines.Find(medicine.Id);
            _context.SaveChanges();
        }
    }
}
