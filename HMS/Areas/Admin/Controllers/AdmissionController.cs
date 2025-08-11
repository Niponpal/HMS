using HMS.Models;
using HMS.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdmissionController(IAdmissionRepository admissionRepository, IHospitalRoomRepository hospitalRoomRepository) : Controller
    {
        public IActionResult Index()
        {
            var data = admissionRepository.GetAllData();
            if (data == null) 
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["HospitalRoomId"] = hospitalRoomRepository.Dropdown();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Admission admission)
        {
            //admission.HospitalRoomId = 1;
            var data = admissionRepository.AddData(admission);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["HospitalRoomId"] = hospitalRoomRepository.Dropdown();
            var data = admissionRepository.GetById(id);
            if(data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Admission admission)
        {
            var data = admissionRepository.GetById(admission.Id);
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
            admissionRepository.UpdateData(data);
             return RedirectToAction("Index");      
        }
        [HttpPost]
        public IActionResult Delete(int id) 
        {
            var data = admissionRepository.DeleteData(id);
            if (data == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Details(int id) 
        {
           var data=admissionRepository.GetById(id);
            return View(data);
        }
    }
}
