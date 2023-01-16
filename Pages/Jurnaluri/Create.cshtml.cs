using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Belu_Ioana_Web.Data;
using Belu_Ioana_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Belu_Ioana_Web.Pages.Jurnaluri
{
    public class CreateModel : JurnalCategoriiPageModel
    {
        private readonly Belu_Ioana_Web.Data.Belu_Ioana_WebContext _context;

        public CreateModel(Belu_Ioana_Web.Data.Belu_Ioana_WebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var jurnal = new Jurnal();
            jurnal.CategorieAlimente = new List<CategorieAliment>();
            PopulateAssignedCategoryData(_context, jurnal);
            return Page();
        }

        [BindProperty]
        public Jurnal Jurnal { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newJurnal = new Jurnal();
            if (selectedCategories != null)
            {
                newJurnal.CategorieAlimente = new List<CategorieAliment>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new CategorieAliment
                    {
                        CategorieID = int.Parse(cat)
                    };
                    newJurnal.CategorieAlimente.Add(catToAdd);
                }
            }
            Jurnal.CategorieAlimente = newJurnal.CategorieAlimente;
            _context.Jurnal.Add(Jurnal);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}

