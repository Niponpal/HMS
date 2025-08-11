using HMS.Models;
using HMS.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PatientController : Controller
    {
        private readonly IPatientRepository _patientRepository;
      
        
        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
          
        }

        public IActionResult Index()
        {
            var data = _patientRepository.GatAllData();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            var data = _patientRepository.AddData(patient);
            if (data == null) 
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _patientRepository.GetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Patient patient) 
        {
            var data = _patientRepository.GetById(patient.Id);
            if (data == null)
            {
                return NotFound();
            }
            data.FullName = patient.FullName;
            data.Gender = patient.Gender;
            data.DateOfBirth = patient.DateOfBirth;
            data.BloodGroup = patient.BloodGroup;
            data.PhoneNumber = patient.PhoneNumber;
            data.Email = patient.Email;
            data.Address = patient.Address;
            data.RegistrationDate = patient.RegistrationDate;   
            data.EmergencyContact = patient.EmergencyContact;
            data.ImagePath = patient.ImagePath;
            data.Description = patient.Description;   
            _patientRepository.Update(data);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id) 
        {
            var data = _patientRepository.GetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(int id) 
        {
            var data = _patientRepository.DeleteData(id);
            if(data == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
           
        }
    }
}
