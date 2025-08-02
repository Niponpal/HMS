using HMS.Models;
using HMS.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class AdmissionController : Controller
    {
        private readonly IAdmissionRepository _admissionRepository;

        public AdmissionController(IAdmissionRepository admissionRepository)
        {
            _admissionRepository = admissionRepository;
        }
        public IActionResult Index()
        {
            var data = _admissionRepository.GetAllData();
            if (data == null) 
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
        public IActionResult Create(Admission admission)
        {
            var data = _admissionRepository.AddData(admission);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _admissionRepository.GetById(id);
            if(data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Admission admission)
        {
            var data = _admissionRepository.GetById(admission.Id);
            if(data == null)
            {
                return NotFound();
            }
            data.Description = admission.Description;
            data.Diagnosis = admission.Diagnosis;
            data.DischargeDate = admission.DischargeDate;
            data.AdmitDate = admission.AdmitDate;
            data.CreatedAt = admission.CreatedAt;
            data.AdvancePayment=admission.AdvancePayment;
            data.ImagePath = admission.ImagePath;
            data.DoctorRemarks = admission.DoctorRemarks;
            data.DischargeStatus = admission.DischargeStatus;
            data.TreatmentPlan = admission.TreatmentPlan;
            _admissionRepository.UpdateData(data);
             return RedirectToAction("Index");      
        }
        [HttpPost]
        public IActionResult Delete(int id) 
        {
            var data = _admissionRepository.DeleteData(id);
            if (data == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Details(int id) 
        {
           var data=_admissionRepository.GetById(id);
            return View(data);
        }
    }
}
