using System.ComponentModel.DataAnnotations;

namespace AwesmeApi.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(10)]
        public string Gender { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
