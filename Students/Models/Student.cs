using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Students.Models
{
    public class Student
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Минимальная длина 5!")]
        public string Name { get; set; }

        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public string DisplayBirthDate { get; set; }

        [Required(ErrorMessage = "Введите Email.")]
        [EmailAddress(ErrorMessage = "Неверно введенный Email.")]
        public string Email { get; set; }

        [Required]
        public string City { get; set; }
    }
}