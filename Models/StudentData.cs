using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facultate2.Models
{
    public class StudentData
    {
        public IEnumerable<Student> Studenti { get; set; }
        public IEnumerable<Specializare> Specializari { get; set; }
        public IEnumerable<StudentSpecializare> StudentSpecializari { get; set; }

    }
}
