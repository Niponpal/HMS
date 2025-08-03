using HMS.Models;
using HMS.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HospitalRoomController : Controller
    {
        private readonly IHospitalRoomRepository _repository;
        public HospitalRoomController(IHospitalRoomRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var data =  _repository.GetAllData();
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
        public IActionResult Create(HospitalRoom hospitalRoom)
        {
            var data = _repository.AddData(hospitalRoom);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        { 
            var data = _repository.GetById(id);
            if(data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(HospitalRoom hospitalRoom)
        {
            var data = _repository.GetById(hospitalRoom.Id);
            if(data == null)
            {
                return NotFound();
            }
            data.RoomNumber = hospitalRoom.RoomNumber;
            data.RoomType = hospitalRoom.RoomType;
            data.IsAvailable = hospitalRoom.IsAvailable;
            data.RoomChargesPerDay = hospitalRoom.RoomChargesPerDay;
            data.Floor= hospitalRoom.Floor;
            data.OccupiedBeds = hospitalRoom.OccupiedBeds;
            data.Description = hospitalRoom.Description;
            data.ImagePath = hospitalRoom.ImagePath;
            data.LastUpdated = DateTime.Now;
            data.Capacity = hospitalRoom.Capacity;
            _repository.UpdateData(data);
            return RedirectToAction("Index"); 
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var data = _repository.GetById(id);
            if(data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(int id) 
        {
           var data = _repository.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            _repository.DeleteData(id);
            return RedirectToAction("Index");
        }
    }
}
