using HMS.Models;
using HMS.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepository _repository;
        public AppointmentController(IAppointmentRepository repository)
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
        public IActionResult Create(Appointment appointment)
        {
            var data = _repository.AddData(appointment);
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
        public IActionResult Edit(Appointment appointment)
        {
            var data = _repository.GetById(appointment.Id);
            if (data == null)
            {
                return NotFound();
            }
            data.Notes = appointment.Notes;
            data.TimeSlot = appointment.TimeSlot;
            data.AppointmentStatus = appointment.AppointmentStatus;
            data.AppointmentDate = appointment.AppointmentDate;
            data.CompletedAt = appointment.CompletedAt;
            data.CreatedAt = appointment.CreatedAt;
            data.Description = appointment.Description;
            data.Symptoms = appointment.Symptoms;
            _repository.UpdateData(data);
            return RedirectToAction("Index");

        }
      
        [HttpGet]
        public IActionResult Details(int id)
        {
            var data = _repository.GetById(id);

            if (data == null)
            {
                return NotFound(); 
            }

            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(int id) 
        {
           var data = _repository.DeleteData(id);
            if(data == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
