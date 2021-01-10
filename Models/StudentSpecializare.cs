using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facultate2.Models
{
    public class StudentSpecializare
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public int SpecializareID { get; set; }
        public Specializare Specializare { get; set; }

    }
}
