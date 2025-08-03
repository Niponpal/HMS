using HMS.Models;
using HMS.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StaffsController : Controller
    {
        private readonly IStaffRepository _staffRepository;
        public StaffsController(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }
        public IActionResult Index()
        {
            var data = _staffRepository.GetAllData();
            if(data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Staff staff)
        {
            var data = _staffRepository.AddData(staff);
            if(data == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _staffRepository.GetById(id);
            if( data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Staff staff)
        {
            var data = _staffRepository.GetById(staff.Id);
            if( data == null)
            {
                return NotFound();
            }
            data.FullName = staff.FullName;
            data.Role = staff.Role;
            data.PhoneNumber = staff.PhoneNumber;
            data.Email = staff.Email;
            data.JoiningDate = staff.JoiningDate;
            data.Status = staff.Status;
            data.Shift = staff.Shift;
            data.Gender = staff.Gender;
            data.Address = staff.Address;
            data.ImagePath = staff.ImagePath;
            data.Description = staff.Description;
            _staffRepository.UpdateData(data);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id) 
        {
            var data = _staffRepository.DeleteData(id);
            if( data == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var data =_staffRepository.GetById(id);
            if ( data == null)
            {
                return NotFound();
            }
            return View(data);
        }
    }
}
