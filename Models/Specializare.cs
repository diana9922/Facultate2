using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Facultate2.Models
{
    public class Specializare
    {
        public int ID { get; set; }
        [Required, StringLength(100, MinimumLength = 3)]
        [Display(Name = "Denumire specializare")]
        public string SpecializareNume { get; set; }
        
        public ICollection<StudentSpecializare> StudentSpecializari { get; set; }
    }
}
