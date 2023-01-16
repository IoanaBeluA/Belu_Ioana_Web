namespace Belu_Ioana_Web.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<CategorieAliment>? CategorieAlimente { get; set; }
    }
}
