namespace eCommerce.Business
{
    public class LigneCommande
    {
        public int Id { get; set; }
        public Produit Produit { get; set; }
        public int Quantite { get; set; }
    }
}