using eCommerce.Business;
using eCommerce.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.Infrastructure
{
    public abstract class CommerceControllerBase : Controller
    {
        public ApplicationDbContext DbContext { get; private set; }
        public Client ConnectedClient { get; private set; }
        public Commande Panier { get; private set; }

        protected CommerceControllerBase() : base()
        {
            DbContext = new ApplicationDbContext();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            Panier = Session["Panier"] as Commande;
            if (Panier == null)
            {
                Panier = new Commande { Statut = CommandeStatut.Panier };
                Session.Add("Panier", Panier);
            }

            if (Request.IsAuthenticated)
            {
                // Warning : l'admin n'est pas un client !!
                ConnectedClient = DbContext.Clients.FirstOrDefault(c => c.Id == User.Identity.GetUserId());
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DbContext.Dispose();
                DbContext = null;
            }

            base.Dispose(disposing);
        }
    }
}