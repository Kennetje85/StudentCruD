﻿using System.ComponentModel.DataAnnotations;

namespace ReactCrud.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; } 
        public string stname { get; set; }  
        public string course { get; set; }  

    }
}
