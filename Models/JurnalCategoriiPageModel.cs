using Microsoft.AspNetCore.Mvc.RazorPages;
using Belu_Ioana_Web.Data;
namespace Belu_Ioana_Web.Models
{
    public class JurnalCategoriiPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Belu_Ioana_WebContext context, Jurnal jurnal)
        {
            var allCategories = context.Categorie;
            var alimentCategorii = new HashSet<int>(jurnal.CategorieAlimente.Select(c => c.CategorieID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = alimentCategorii.Contains(cat.ID)
                });
            }
        }
        public void UpdateCategorieAliment(Belu_Ioana_WebContext context, string[] selectedCategories, Jurnal jurnalToUpdate)
        {
            if (selectedCategories == null)
            {
                jurnalToUpdate.CategorieAlimente = new List<CategorieAliment>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var alimentCategorii = new HashSet<int>
            (jurnalToUpdate.CategorieAlimente.Select(c => c.Categorie.ID));
            foreach (var cat in context.CategorieAliment)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!alimentCategorii.Contains(cat.ID))
                    {
                        jurnalToUpdate.CategorieAlimente.Add(
                        new CategorieAliment
                        {
                            JurnalID = jurnalToUpdate.ID,
                            CategorieID = cat.ID
                        });
                    }
                }
                else
                {
                    if (alimentCategorii.Contains(cat.ID))
                    {
                        CategorieAliment courseToRemove = jurnalToUpdate
                        .CategorieAlimente
                        .SingleOrDefault(i => i.CategorieID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }

    }
}
