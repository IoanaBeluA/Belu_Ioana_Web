using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Belu_Ioana_Web.Data;
using Belu_Ioana_Web.Models;

namespace Belu_Ioana_Web.Pages.Jurnaluri
{
    public class EditModel : JurnalCategoriiPageModel
    {
        private readonly Belu_Ioana_Web.Data.Belu_Ioana_WebContext _context;

        public EditModel(Belu_Ioana_Web.Data.Belu_Ioana_WebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Jurnal Jurnal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Jurnal.Find(id) == null)
            {
                return NotFound();
            }

            Jurnal = await _context.Jurnal
            .Include(b => b.CategorieAlimente).ThenInclude(b => b.Categorie)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);

            if (Jurnal == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jurnalToUpdate = await _context.Jurnal
                .Include(i => i.CategorieAlimente)
                .ThenInclude(i => i.Categorie)
                .FirstOrDefaultAsync(s => s.ID == id);
            if (jurnalToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Jurnal>(jurnalToUpdate,"Jurnal",
            i => i.Zi, i => i.Aliment,
            i => i.Calorii, i => i.Data))
            {
                UpdateCategorieAliment(_context, selectedCategories, jurnalToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateCategorieAliment(_context, selectedCategories, jurnalToUpdate);
            PopulateAssignedCategoryData(_context, jurnalToUpdate);
            return Page();
        }

        private bool JurnalExists(int id)
        {
          return _context.Jurnal.Any(e => e.ID == id);
        }
    }
}
