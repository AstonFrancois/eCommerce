using eCommerce.Business;
using eCommerce.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.Controllers
{
    public class PanierController : CommerceControllerBase
    {
        public ActionResult Index()
        {
            return View(Panier);
        }

        [HttpPost]
        public ActionResult Ajouter(int? id)
        {
            if (!id.HasValue)
            {
                return View("Error");
            }

            Produit p = DbContext.Produits.Find(id);
            Panier.AjouterProduit(p, 1);
            return RedirectToAction("Index", "Produit");
        }
    }
}