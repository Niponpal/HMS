using HMS.Models;
using HMS.Repositorys;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MedicalRecordController : Controller
    {
        private readonly IMedicalRecordRepository _repository;
        private readonly IPatientRepository _medicalRecordRepository;

       
        public MedicalRecordController(IMedicalRecordRepository repository, IPatientRepository medicalRecordRepository)
        {
            _repository = repository;
            _medicalRecordRepository = medicalRecordRepository;
        }

        public IActionResult Index()
        {
            var data = _repository.GetAllData();
            if (data == null)
            { 
            return NotFound();
            }
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["PatientId"] = _medicalRecordRepository.DropdownMedical();
            return View(); 
        }
        [HttpPost]
        public IActionResult Create(MedicalRecord medicalRecord)
        {
            var data = _repository.AddData(medicalRecord);
            if (data == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");  
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _repository.GetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(MedicalRecord medicalRecord)
        {
            var data= _repository.GetById(medicalRecord.Id);
            if(data == null)
            {
                return NotFound();
            }
            data.Prescription = medicalRecord.Prescription;
            data.Description = medicalRecord.Description;
            data.RecordDate = medicalRecord.RecordDate;
            data.ImagePath = medicalRecord.ImagePath;
            data.CreatedAt = medicalRecord.CreatedAt;
            data.Diagnosis = medicalRecord.Diagnosis;
            data.NextVisitSuggestion = medicalRecord.NextVisitSuggestion;
            data.TestResults = medicalRecord.TestResults;
            data.Notes = medicalRecord.Notes;
            data.Symptoms=medicalRecord.Symptoms;
            _repository.UpdateDate(data);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var data= _repository.GetById(id) ;
            if(data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(int id) 
        {
           var data= _repository.DeleteData(id);
            if (data == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
