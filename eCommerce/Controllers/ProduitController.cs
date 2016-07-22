using eCommerce.Business;
using eCommerce.Infrastructure;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace eCommerce.Controllers
{
    public class ProduitController : CommerceControllerBase
    {
        public ActionResult Index(int? id)
        {
            // Rappel, ici id = id de la catégorie
            IEnumerable<Produit> produits = DbContext.Produits.Include(p => p.Categorie).Where(p => p.Categorie.Id == id || !id.HasValue);

            return View(produits);
        }
    }
}