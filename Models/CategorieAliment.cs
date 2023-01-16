namespace Belu_Ioana_Web.Models
{
    public class CategorieAliment
    {
        public int ID { get; set; }
        public int JurnalID { get; set; }
        public Jurnal Jurnal { get; set; }
        public int CategorieID { get; set; }
        public Categorie Categorie { get; set; }
    }
}
