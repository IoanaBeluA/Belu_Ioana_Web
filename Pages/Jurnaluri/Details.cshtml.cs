using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Belu_Ioana_Web.Data;
using Belu_Ioana_Web.Models;

namespace Belu_Ioana_Web.Pages.Jurnaluri
{
    public class DetailsModel : PageModel
    {
        private readonly Belu_Ioana_Web.Data.Belu_Ioana_WebContext _context;

        public DetailsModel(Belu_Ioana_Web.Data.Belu_Ioana_WebContext context)
        {
            _context = context;
        }

      public Jurnal Jurnal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Jurnal == null)
            {
                return NotFound();
            }

            var jurnal = await _context.Jurnal.FirstOrDefaultAsync(m => m.ID == id);
            if (jurnal == null)
            {
                return NotFound();
            }
            else 
            {
                Jurnal = jurnal;
            }
            return Page();
        }
    }
}
