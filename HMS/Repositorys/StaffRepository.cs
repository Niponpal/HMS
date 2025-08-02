using HMS.Data;
using HMS.Models;

namespace HMS.Repositorys
{
    public class StaffRepository : IStaffRepository
    {
        private readonly ApplicationDbContext _context;
        public StaffRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public string AddData(Staff staff)
        {
          _context.Staffs.Add(staff);
          _context.SaveChanges();
          return "Data Added Sucessfully";
        }

        public string DeleteData(int id)
        {
            var data = _context.Staffs.Find(id);
            if (data== null)
            {
                return "Fot Found";
            }
            _context.Staffs.Remove(data);
            _context.SaveChanges();
            return "Data Delete Sucessfully";
        }

        public IEnumerable<Staff> GetAllData()
        {
            var data = _context.Staffs.ToList();
            return data;
          
        }

        public Staff GetById(int id)
        {
           var data =_context.Staffs.Find(id);
            return data;
        }

        public void UpdateData(Staff staff)
        {
            _context.Staffs.Find(staff.Id);
            _context.SaveChanges();
           
        }
    }
}
