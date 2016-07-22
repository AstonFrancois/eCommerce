namespace eCommerce.Business
{
    public class Adresse
    {
        public int Id { get; set; }
        public string Ligne1 { get; set; }
        public string Ligne2 { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
    }
}