using eCommerce.Business;
using eCommerce.Infrastructure;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.Controllers
{
    public class CommandeController : CommerceControllerBase
    {
        public ActionResult Display(int id)
        {
            return View(DbContext.Commande.Include("LignesCommande.Produit").Single(c => c.Id == id));
        }

        public ActionResult Create()
        {
            Commande nvlleCommande = Panier;
            nvlleCommande.Statut = CommandeStatut.Validee;
            nvlleCommande.ValidationDate = DateTime.Now;
            DbContext.Commande.Add(nvlleCommande);
            DbContext.SaveChanges();

            Session.Remove("Panier");

            return RedirectToAction("Display",new { id = nvlleCommande.Id });
        }
    }
}