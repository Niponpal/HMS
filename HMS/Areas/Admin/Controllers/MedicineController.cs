using HMS.Models;
using HMS.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MedicineController : Controller
    {
        private readonly IMedicineRepository _mediicineRepository;
        public MedicineController(IMedicineRepository mediicineRepository)
        {
            _mediicineRepository = mediicineRepository;
        }
        public IActionResult Index()
        {
            var data = _mediicineRepository.GetAllData();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Medicine medicine)
        {
            var datra = _mediicineRepository.AddData(medicine);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _mediicineRepository.GetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Medicine medicine)
        {
            var data = _mediicineRepository.GetById(medicine.Id);
            if(data == null)
            {
                return View(null);
            }
            data.MedicineName= medicine.MedicineName;
            data.ExpiryDate= medicine.ExpiryDate;
            data.Manufacturer= medicine.Manufacturer;
            data.BatchNumber= medicine.BatchNumber;
            data.StockQuantity= medicine.StockQuantity;
            data.PricePerUnit= medicine.PricePerUnit;
            data.UsageInstructions= medicine.UsageInstructions;
            data.AddedDate= medicine.AddedDate;
            data.Category= medicine.Category;
            data.Description= medicine.Description;
            data.ImagePath= medicine.ImagePath;
            _mediicineRepository.UpdateData(data);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var data = _mediicineRepository.GetById(id);
            if( data == null)
            {
                return View(null);
            }
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var data = _mediicineRepository.DeleteData(id);
            if (data == null)
            {
                return View(null);
            }
            return RedirectToAction("Index");
        }
    }
}
