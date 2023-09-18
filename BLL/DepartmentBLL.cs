using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using test.Context;
using test.Models;

namespace test.BLL
{
    public class DepartmentBLL
    {
        itiContext db = new itiContext();
        public List<Department> getAll() => db.Departments.Include(d=>d.students).ToList();
        public Department getDepartment(int id) => db.Departments.SingleOrDefault(d => d.Id == id);
        public void Add(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var dept=getDepartment(id);
            foreach(var student in dept.students) {
                student.DeptId = null;
            }
            db.Departments.Remove(dept);
            db.SaveChanges();
        }
        public void update(Department dept)
        {
            db.Departments.Update(dept);
            db.SaveChanges();
        }
        
    }
}
