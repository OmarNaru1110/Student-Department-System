using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using project.ActionFilters;
using test.BLL;
using test.Context;
using test.Models;

namespace test.Controllers
{
    public class StudentController:Controller
    {
  
        StudentBLL studentBLL=new StudentBLL();
        DepartmentBLL departmentBLL=new DepartmentBLL();

        [CreatesStudentException]// calling the action filter I made
        public IActionResult Index()
        {
            /*
             let's simulate that we have an error in this action, 
             first of all, we code in protective programming way
             trying not to collide with errors, after that if we 
             suspect that a line of code will generate an error 
             we do the try catch approach,
             we can protect our code furthermore in the scenario where
             we don't suspect that this action will generate an error
             but if happened we will display to the user an error view
             explaining what happened or anything (this is what we gonna do here 
             and we call this *ACTION FILTERS*)
            */

            /*  int x = int.Parse("sf"); => error simulation */
            
            var students = studentBLL.getAll();
            return View(students);
        }
        public IActionResult Search(string item)
        {
            if (item is null)
                return BadRequest();
            IEnumerable<Student> students = studentBLL.SearchByName(item);
            if (students.IsNullOrEmpty())
                return NotFound("Nothing Matched");
   
            return View(students);
            
        }
        public IActionResult Details(int? id)
        { 
            if (id is null)
                return BadRequest();
            Student student = studentBLL.getStudent(id.Value);
            if(student is null)
                return NotFound();
            return View(student);
        }
        // model binder priorities from higher to lower :
        // model binder will search first in Request.Form => Request.RouteValues => Request.Query
        // this is the default behaviour but what if I wanted the model binder to just search in
        // queryString or RouteValues or PostedData(Form)
        // you have to add some attribute before the paramter, see parameter of Create function below
        // [FromForm] : Search in posted Data (Request.Form)
        // [FromQuery] : Search in query string (Request.Query)
        // [FromRoute] : Search in routed values (Request.RouteValues)

        [HttpPost] //cuz i have 2 functions with the same name, THIS IS CALLES ACTION SELECTOR
        public IActionResult Create(/*[FromRoute]*/ Student st) { 

            if(ModelState.IsValid)
            {
                studentBLL.Add(st);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.departments = new SelectList(departmentBLL.getAll(), "Id", "Name");
                return View(st);
            }
        }

        [HttpGet]
        public IActionResult Create() {
          ViewBag.departments=new SelectList(departmentBLL.getAll(),"Id","Name");
            return View("Create");
        }
        public IActionResult Delete(int? id) {
            if(id is null) 
                return BadRequest();
            var st=studentBLL.getStudent(id.Value);
            if(st is null)
                return NotFound("There is no such student with the id u sent");
            studentBLL.Delete(st);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Update(Student st) {
            studentBLL.Update(st);
            
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id is null)
                return BadRequest();
            Student st = studentBLL.getStudent(id.Value);
            if (st is null)
                return NotFound("No student with such id");
            ViewBag.depts = new SelectList(departmentBLL.getAll(), "Id", "Name");
            return View(st);
        }
    }
}
