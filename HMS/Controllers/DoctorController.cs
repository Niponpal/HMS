using HMS.Models;
using HMS.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorRepository _repository;
        public DoctorController(IDoctorRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var data = _repository.GetAllData();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            var data = _repository.AddData(doctor);
            if(data== null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _repository.GetById(id);
            if (data == null) 
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Doctor doctor)
        {
            var data = _repository.GetById(doctor.Id);
            if( data == null)
            {
                return NotFound();
            }
            data.FullName = doctor.FullName;
            data.Specialization = doctor.Specialization;
            data.PhoneNumber = doctor.PhoneNumber;
            data.Email = doctor.Email;
            data.Qualification = doctor.Qualification;
            data.ExperienceYears = doctor.ExperienceYears;
            data.Gender = doctor.Gender;
            data.JoiningDate = doctor.JoiningDate;
            data.Status = doctor.Status;
            data.ImagePath = doctor.ImagePath;
            data.Description = doctor.Description;
            _repository.UpdateData(data);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var data = _repository.GetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var data = _repository.DeleteData(id);
            return RedirectToAction("Index");
        }
    }
}
