using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Models
{
    public class Student
    {
        //1 department to many students
        public int Id { get; set; }
        [StringLength(50,MinimumLength =2),Required]
        public string Name { get; set; }

        [RegularExpression(@"[a-zA-Z0-9]+@[a-zA-z]+.{2,4}")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name="Confirm Password"), Compare("Password"), DataType(DataType.Password)]
        public string CPassword { get; set; }
        [Range(18,27)]  
        public int Age { get; set; }
        [ForeignKey("Department")]
        public int? DeptId { get; set; }
        public virtual Department Department { get; set; }
        //جرب انك موديل الديبارتمينت وحط فيه كوليكشن الستيودينت بس من غير ما تعرفه 
        // وجرب حط داتا فيه وشوف واعمل جوين وشوف ايه اللي هيحصل    
    }
}
