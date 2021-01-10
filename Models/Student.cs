using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Facultate2.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Required, StringLength(50, MinimumLength = 2)]
        public string Nume { get; set; }
        [Required, StringLength(50, MinimumLength = 2)]
        public string Prenume { get; set; }
        [Required, StringLength(5, MinimumLength = 1)]
        [Display(Name="Numar Matricol")]
        public string NrMatricol { get; set; }
       
        [Display(Name = "Profesor Coordonator")]
        public int ProfesorID { get; set; }
        public Profesor Profesor { get; set; }
        [Display(Name = "Specializare")]
        public ICollection<StudentSpecializare> StudentSpecializari { get; set; }
    }
}
