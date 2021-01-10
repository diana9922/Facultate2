using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Facultate2.Data;
using Facultate2.Models;

namespace Facultate2.Pages.Studenti
{
    public class CreateModel : StudentSpecializariPageModel
    {
        private readonly Facultate2.Data.Facultate2Context _context;

        public CreateModel(Facultate2.Data.Facultate2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ProfesorID"] = new SelectList(_context.Set<Profesor>(), "ID", "ProfesorNume");
            var student = new Student();
            student.StudentSpecializari = new List<StudentSpecializare>();
            PopulateAssignedSpecializareData(_context, student);
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedSpecializari)
        {
            var newStudent = new Student();
            if (selectedSpecializari != null)
            {
                newStudent.StudentSpecializari = new List<StudentSpecializare>();
                foreach (var cat in selectedSpecializari)
                {
                    var catToAdd = new StudentSpecializare
                    {
                        SpecializareID = int.Parse(cat)
                    };
                    newStudent.StudentSpecializari.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Student>(
            newStudent,
            "Student",
             i => i.Nume, i => i.Prenume,
            i => i.NrMatricol, i => i.ProfesorID))
            {
                _context.Student.Add(newStudent);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedSpecializareData(_context, newStudent);
            return Page();
        }
    }

    
  
        }
    