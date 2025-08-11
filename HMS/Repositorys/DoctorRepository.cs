using HMS.Data;
using HMS.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HMS.Repositorys
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _context;

        public DoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public string AddData(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            return "add data successfully";
        }
        public string DeleteData(int id)
        {
          var data= _context.Doctors.Find(id);
            if (data == null)
            {
                return "Not Found";
            }
            _context.Doctors.Remove(data);
            _context.SaveChanges();
            return "Delete Data Successfully";
        }

        public IEnumerable<SelectListItem> Dropdown()
        {
            var data = _context.Doctors.Select(x => new SelectListItem
            {
                Text = x.Email,
                Value = x.Id.ToString()
            }).ToList();
            return data;
        }

        public IEnumerable<Doctor> GetAllData()
        {
           var data = _context.Doctors.ToList();
            return data;
        }

        public Doctor GetById(int id)
        {
           var data= _context.Doctors.Find(id);
            return data;
        }

        public void UpdateData(Doctor doctor)
        {
            _context.Doctors.Find(doctor.Id);
            _context.SaveChanges();
        }
    }
}
