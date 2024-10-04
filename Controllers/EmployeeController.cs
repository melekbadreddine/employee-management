using Microsoft.AspNetCore.Mvc;
using VotreNamespace.Models;
using VotreNamespace.Models.Repositories;

namespace VotreNamespace.Controllers
{
    public class EmployeeController : Controller
    {
        readonly IRepository<Employee> employeeRepository;

        public EmployeeController(IRepository<Employee> empRepository)
        {
            employeeRepository = empRepository;
        }

        public ActionResult Index()
        {
            return View(employeeRepository.GetAll());
        }

        public ActionResult Details(int id)
        {
            var employee = employeeRepository.FindByID(id);
            if (employee == null)
                return NotFound();
            return View(employee);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee e)
        {
            if (ModelState.IsValid)
            {
                employeeRepository.Add(e);
                return RedirectToAction(nameof(Index));
            }
            return View(e);
        }

        public ActionResult Edit(int id)
        {
            var employee = employeeRepository.FindByID(id);
            if (employee == null)
                return NotFound();
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee newemployee)
        {
            if (id != newemployee.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                employeeRepository.Update(id, newemployee);
                return RedirectToAction(nameof(Index));
            }
            return View(newemployee);
        }

        public ActionResult Delete(int id)
        {
            var employee = employeeRepository.FindByID(id);
            if (employee == null)
                return NotFound();
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employeeRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Search(string term)
        {
            var results = employeeRepository.Search(term);
            return View("Index", results);
        }
    }
}