using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class Department
    {
        public int Id { get; set; }
        [StringLength(20,MinimumLength =2),Required]
        public string Name { get; set; }

        public virtual ICollection<Student> students { get; set; }=new HashSet<Student>();
    }
}
