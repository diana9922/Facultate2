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
    public class IndexModel : PageModel
    {
        private readonly Facultate2.Data.Facultate2Context _context;

        public IndexModel(Facultate2.Data.Facultate2Context context)
        {
            _context = context;
        }

        public IList<Specializare> Specializare { get;set; }

        public async Task OnGetAsync()
        {
            Specializare = await _context.Specializare.ToListAsync();
        }
    }
}
