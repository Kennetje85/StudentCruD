using System.ComponentModel.DataAnnotations;

namespace ReactCrud.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string stname { get; set; }

        [Required]
        public string course { get; set; }  

    }
}
