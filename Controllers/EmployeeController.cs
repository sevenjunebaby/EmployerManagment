using Microsoft.AspNetCore.Mvc;
using tp3.Models;
using tp3.Models.Repositories;


public class EmployeeController : Controller
{
    private readonly IRepository<Employee> employeeRepository;

    // Injection de dépendance
    public EmployeeController(IRepository<Employee> empRepository)
    {
        employeeRepository = empRepository;
    }

    // GET: /Employee/
    public ActionResult Index()
    {
        var employees = employeeRepository.GetAll();
        return View(employees);
    }

    // GET: /Employee/Details/5
    public ActionResult Details(int id)
    {
        var emp = employeeRepository.FindByID(id);
        if (emp == null)
            return NotFound();

        return View(emp);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Employee e)
    {
        if (ModelState.IsValid)
        {
            employeeRepository.Add(e);
            return RedirectToAction("Index");
        }

        return View(e);
    }


    public ActionResult Edit(int id)
    {
        var emp = employeeRepository.FindByID(id);
        if (emp == null)
            return NotFound();

        return View(emp);
    }

    [HttpPost]
    public ActionResult Edit(int id, Employee newemployee)
    {
        if (ModelState.IsValid)
        {
            employeeRepository.Update(id, newemployee);
            return RedirectToAction("Index");
        }

        return View(newemployee);
    }


    public ActionResult Delete(int id)
    {
        var emp = employeeRepository.FindByID(id);
        if (emp == null)
            return NotFound();

        return View(emp);
    }


    [HttpPost]
    public ActionResult Delete(int id, Employee e)
    {
        employeeRepository.Delete(id);
        return RedirectToAction("Index");
    }

    public ActionResult Search(string term)
    {
        var results = employeeRepository.Search(term);
        return View("Index", results);
    }
}
