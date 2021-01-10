using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Facultate2.Data;
using Facultate2.Models;

namespace Facultate2.Pages.Specializari
{
    public class DetailsModel : PageModel
    {
        private readonly Facultate2.Data.Facultate2Context _context;

        public DetailsModel(Facultate2.Data.Facultate2Context context)
        {
            _context = context;
        }

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
    }
}
