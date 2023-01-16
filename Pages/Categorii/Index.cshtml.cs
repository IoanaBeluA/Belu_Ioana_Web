using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Belu_Ioana_Web.Data;
using Belu_Ioana_Web.Models;

namespace Belu_Ioana_Web.Pages.Categorii
{
    public class IndexModel : PageModel
    {
        private readonly Belu_Ioana_Web.Data.Belu_Ioana_WebContext _context;

        public IndexModel(Belu_Ioana_Web.Data.Belu_Ioana_WebContext context)
        {
            _context = context;
        }

        public IList<Categorie> Categorie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Categorie != null)
            {
                Categorie = await _context.Categorie.ToListAsync();
            }
        }
    }
}
