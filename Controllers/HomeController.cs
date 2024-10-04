using Atelier1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VotreNamespace.Models;
using VotreNamespace.Models.Repositories;

namespace Atelier1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Employee> _employeeRepository;

        public HomeController(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            var employees = _employeeRepository.GetAll();
            return View(employees);
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
