using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Facultate2.Data;
using Facultate2.Models;

namespace Facultate2.Pages.Studenti
{
    public class EditModel : StudentSpecializariPageModel
    {
        private readonly Facultate2.Data.Facultate2Context _context;

        public EditModel(Facultate2.Data.Facultate2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Student
             .Include(b => b.Profesor)
             .Include(b => b.StudentSpecializari).ThenInclude(b => b.Specializare)
             .AsNoTracking()
              .FirstOrDefaultAsync(m => m.ID == id);

            if (Student == null)
            {
                return NotFound();
            }
            PopulateAssignedSpecializareData(_context, Student);
            ViewData["ProfesorID"] = new SelectList(_context.Set<Profesor>(), "ID", "ProfesorNume");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedSpecializari)
        {
            if (id == null)
            {
                return NotFound();
            }
            var studentToUpdate = await _context.Student
            .Include(i => i.Profesor)
            .Include(i => i.StudentSpecializari)
            .ThenInclude(i => i.Specializare)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (studentToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Student>(
             studentToUpdate,
            "Student",
            i => i.Nume, i => i.Prenume,
            i => i.NrMatricol, i => i.Profesor))
            {
                UpdateStudentSpecializari(_context, selectedSpecializari, studentToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateStudentSpecializari(_context, selectedSpecializari,studentToUpdate);
            PopulateAssignedSpecializareData(_context, studentToUpdate);
            return Page();
        }
    }
}
    
