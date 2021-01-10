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

namespace Facultate2.Pages.Specializari
{
    public class EditModel : PageModel
    {
        private readonly Facultate2.Data.Facultate2Context _context;

        public EditModel(Facultate2.Data.Facultate2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Specializare Specializare { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Specializare = await _context.Specializare.FirstOrDefaultAsync(m => m.ID == id);

            if (Specializare == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Specializare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecializareExists(Specializare.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SpecializareExists(int id)
        {
            return _context.Specializare.Any(e => e.ID == id);
        }
    }
}
