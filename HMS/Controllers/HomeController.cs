using System.Diagnostics;
using System.Threading.Tasks;
using HMS.Models;
using HMS.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IDoctorRepository _doctorRepository;

        public HomeController(ILogger<HomeController> logger, IDoctorRepository doctorRepository)
        {
            _logger = logger;
            _doctorRepository = doctorRepository;
        }

        public async Task<IActionResult> Index()
        {
            List<Doctor> data = new List<Doctor>();
            data = (List<Doctor>) _doctorRepository.GetAllData();
            return View(data);
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
