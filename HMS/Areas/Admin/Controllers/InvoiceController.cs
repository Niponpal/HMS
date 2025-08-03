using HMS.Models;
using HMS.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceRepository _invoiceRepository;
        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }
        public IActionResult Index()
        {
            var data = _invoiceRepository.GetAllData();
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
        public IActionResult Create(Invoice invoice)
        {
            var data = _invoiceRepository.AddData(invoice);
            if (data == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _invoiceRepository.GetById(id);
            if (data == null) 
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Invoice invoice)
        {
            var data = _invoiceRepository.GetById(invoice.Id);
            if(data == null)
            {
                return NotFound();
            }
            data.InvoiceDate = DateTime.Now;
            data.ConsultationFee = invoice.ConsultationFee;
            data.RoomChrge  = invoice.RoomChrge;
            data.MedicineCharge = invoice.MedicineCharge;
            data.LabTestCharge = invoice.LabTestCharge;
            data.OtherCharges = invoice.OtherCharges;
            data.Discount= invoice.Discount;
            data.TotalAmount = invoice.TotalAmount;
            data.PaymentStatus = invoice.PaymentStatus;
            data.ImagePath = invoice.ImagePath;
            data.Description = invoice.Description;
            _invoiceRepository.UpdateData(data);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id) 
        {
            var data = _invoiceRepository.DeleteData(id);
            if( data == null) 
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id) 
        {
            var data = _invoiceRepository.GetById(id);
            return View(data);
        }
    }
}
