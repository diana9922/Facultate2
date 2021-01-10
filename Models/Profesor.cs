using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Facultate2.Models
{
    public class Profesor
    {
        public int ID { get; set; }
      
        [Display(Name = "Nume profesor")]
        public string ProfesorNume { get; set; }
        [Required, StringLength(50, MinimumLength = 2)]
        [Display(Name = "Prenume profesor")]
        public string ProfesorPrenume { get; set; }
        public string Titlu { get; set; }
        
        public ICollection<Student> Studenti { get; set; }
    }
}
