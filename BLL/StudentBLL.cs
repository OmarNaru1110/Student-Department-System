using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using test.Context;
using test.Models;

namespace test.BLL
{
    public class StudentBLL
    {
        public itiContext db = new itiContext();
        public List<Student> getAll()
        {
           return db.Students.Include(s => s.Department).ToList();
        }

        public Student getStudent(int id) => getAll().SingleOrDefault(s=>s.Id==id);

        public Student Add(Student st)
        {
            db.Students.Add(st);
            db.SaveChanges();
            return st;
        }
        public void Delete(Student st) {
            db.Students.Remove(st);
            db.SaveChanges();
        }
        public void Update(Student st){
            db.Students.Update(st);
            db.SaveChanges();
        }
        
    }
}
