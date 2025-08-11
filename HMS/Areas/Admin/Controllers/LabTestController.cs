using HMS.Models;
using HMS.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LabTestController : Controller
    {
        private readonly ILabTestRepository _testRepository;
        private readonly IPatientRepository _patientRepository;
     

        public LabTestController(ILabTestRepository testRepository, IPatientRepository patientRepository)
        {
            _testRepository = testRepository;
            _patientRepository = patientRepository;
        }

        public IActionResult Index()
        {
            var data = _testRepository.GetAllData();
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["PatientId"] = _patientRepository.Dropdown();
            return View();
        }
        [HttpPost]
        public IActionResult Create(LabTest labTest)
        {
            var data = _testRepository.AddData(labTest);
            if (data == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _testRepository.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(LabTest labTest)
        {
            var data = _testRepository.GetById(labTest.Id);
            if (data == null)
            {
                return NotFound();
            }
            data.TestName = labTest.TestName;
            data.TestDate = labTest.TestDate;
            data.TestResult = labTest.TestResult;
            data.Status = labTest.Status;
            data.TestFee = labTest.TestFee;
            data.Notes = labTest.Notes;
            data.CreatedAt = labTest.CreatedAt;
            data.ImagePath = labTest.ImagePath;
            data.Description = labTest.Description;
            _testRepository.UpdateData(data);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var data = _testRepository.GetById(id);
            if(data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var data = _testRepository.DeleteData(id);
            return RedirectToAction("Index");
        }
    }
}
