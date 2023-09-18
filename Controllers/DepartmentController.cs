using Microsoft.AspNetCore.Mvc;
using test.BLL;
using test.Models;

namespace project.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentBLL departmentBLL = new DepartmentBLL();
        public IActionResult Index()
        {
            var departments = departmentBLL.getAll();
            return View(departments);
        }
        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest("U didn't provide the id");

            var department = departmentBLL.getDepartment(id.Value);
            if (department is null)
                return NotFound("No department with such id");
            return View(department);
        }
        [HttpPost]
        public IActionResult Create(Department d)
        {
            if (d is null)
                return BadRequest();
            departmentBLL.Add(d);
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();
            departmentBLL.Delete(id.Value);

            return RedirectToAction("index");
        }
        [HttpPost]
        public IActionResult Update(Department dept)
        {
            departmentBLL.update(dept);
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id is null)
                return BadRequest("U didn't provide the id");

            var department = departmentBLL.getDepartment(id.Value);
            if (department is null)
                return NotFound("No department with such id");

            return View(department);
        }
    }
}
