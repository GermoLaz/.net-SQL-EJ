using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Cursos.Models
{
    public class Person
    {
        public int? id { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        public string name { get; set; }
        [Display(Name = "Apellido")]
        [Required]
        public string lastName { get; set; }
        [Display(Name = "DNI")]
        [Required]
        public string DNI { get; set; }
        [Display(Name = "Fecha de nacimiento")]
        [StringLength(10)]
        [Required]
        public string birthDate { get; set; }
        [Display(Name = "Genero")]
        [Required]
        public string gender { get; set; }
    }

    public class Teacher : Person 
    { 
    }

    public class Student : Person
    {
        [Display(Name = "Fecha de admision")]
        [StringLength(10)]
        [Required]
        public string admissionDate { get; set; }
        [Display(Name = "Carrera")]
        [Required]
        public string career { get; set; }
        [Display(Name = "Direccion")]
        public string address { get; set; }
    }


}
