using System.Collections.Generic;

namespace eCommerce.Business
{
    public class Client
    {
        public string Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public Adresse Adresse { get; set; }
        public ICollection<Commande> Commandes { get; set; }
    }
}