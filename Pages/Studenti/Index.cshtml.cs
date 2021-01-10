using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Facultate2.Data;
using Facultate2.Models;

namespace Facultate2.Pages.Studenti
{
    public class IndexModel : PageModel
    {
        private readonly Facultate2.Data.Facultate2Context _context;

        public IndexModel(Facultate2.Data.Facultate2Context context)
        {
            _context = context;
        }

        public IList<Student> Student { get; set; }

        public StudentData StudentD { get; set; }
        public int StudentID { get; set; }
        public int SpecializareID { get; set; }
        public async Task OnGetAsync(int? id, int? specializareID)
        {
            StudentD = new StudentData();

            StudentD.Studenti = await _context.Student
            .Include(b => b.Profesor)
            .Include(b => b.StudentSpecializari)
            .ThenInclude(b => b.Specializare)
            .AsNoTracking()
            .OrderBy(b => b.Nume)
            .ToListAsync();
            if (id != null)
            {
                StudentID = id.Value;
                Student student = StudentD.Studenti
                .Where(i => i.ID == id.Value).Single();
                StudentD.Specializari = student.StudentSpecializari.Select(s => s.Specializare);
            }
        }
    }
}