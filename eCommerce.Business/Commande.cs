using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Business
{
    public class Commande
    {
        public Commande()
        {
            LignesCommande = new List<LigneCommande>();
        }

        public int Id { get; set; }
        public Client Client { get; set; }
        public ICollection<LigneCommande> LignesCommande { get; set; }
        public CommandeStatut Statut { get; set; }
        public DateTime ValidationDate { get; set; }
        public Adresse Adresse { get; set; }

        public int NbArticles
        {
            get
            {
                return LignesCommande.Sum(lc => lc.Quantite);
            }
        }

        public decimal PrixTotal
        {
            get
            {
                return LignesCommande.Sum(lc => lc.Quantite * lc.Produit.PrixUnitaire);
            }
        }

        public void AjouterProduit(Produit produit, int quantite)
        {
            LigneCommande produitAlreadyHere = LignesCommande.FirstOrDefault(lc => lc.Produit.Id == produit.Id);

            if (produitAlreadyHere != null)
            {
                produitAlreadyHere.Quantite += quantite;
            }
            else
            {
                LignesCommande.Add(new LigneCommande { Produit = produit, Quantite = quantite });
            }
        }
    }
}