using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Cursos.Models
{
    public class Coursee
    {
        public int? id { get; set; }
        [Display(Name = "Nombre del curso")]
        [Required]
        public string name { get; set; }
    }

    public class StudentXCourse
    {
        public int? id { get; set; }
        [Display(Name = "Selecciona un curso")]
        [Required]
        public int course { get; set; }
        [Display(Name = "Selecciona un alumno")]
        [Required]
        public int student { get; set; }
        [Display(Name = "Año")]
        [Required]
        public int year { get; set; }
        [Display(Name = "Semestre")]
        [Required]
        public int semester { get; set; }
    }
}
