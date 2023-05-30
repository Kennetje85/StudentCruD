using System.ComponentModel.DataAnnotations;

namespace ReactCrud.Models
{
    public class Project
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }

        public string hyperlink { get; set; }   
    }
}
