namespace eCommerce.Migrations
{
    using Business;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<eCommerce.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(eCommerce.Models.ApplicationDbContext context)
        {
            // ajout de catégorie
            Categorie parfums = new Categorie { Nom = "Parfums" };
            Categorie savons = new Categorie { Nom = "Bains et savons" };
            Categorie cheveux = new Categorie { Nom = "Soins des cheveux" };

            context.Categories.AddOrUpdate(c => c.Nom, parfums, savons, cheveux);

            // ajout de produits
            Produit p1 = new Produit { Nom = "Sent bon", Categorie = parfums, PrixUnitaire = 12.54m, Stock = 100, Description = "Super parfum qui sent très bon !!" };
            Produit p8 = new Produit { Nom = "Sent bon aussi", Categorie = parfums, PrixUnitaire = 129.80m, Stock = 11, Description = "Super parfum qui sent super trop bon !!" };
            Produit p3 = new Produit { Nom = "N° 5", Categorie = parfums, PrixUnitaire = 179.50m, Stock = 20, Description = "On ne le présente plus..." };

            Produit p2 = new Produit { Nom = "Peuchère !", Categorie = savons, PrixUnitaire = 17.00m, Stock = 50, Description = "Le savon de Marseilles !" };
            Produit p5 = new Produit { Nom = "Lavande", Categorie = savons, PrixUnitaire = 15.49m, Stock = 75, Description = "Bah vi avec des morceaux de lavande à l'intérieur..." };

            Produit p4 = new Produit { Nom = "Bouclette", Categorie = cheveux, PrixUnitaire = 5.99m, Stock = 1250, Description = "Fait les cheveux tout bouclés" };
            Produit p7 = new Produit { Nom = "Iroquois", Categorie = cheveux, PrixUnitaire = 12.54m, Stock = 13, Description = "A la mode punk" };

            context.Produits.AddOrUpdate(p => p.Nom, p1, p2, p3, p4, p5, p7, p8);

            // ajout de client
            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);
            var appUser1 = new ApplicationUser { UserName = "toto@toto.fr" };
            manager.Create(appUser1, "Password@123");

            var admin = new ApplicationUser { UserName = "admin@admin.fr" };
            manager.Create(admin, "Password@123");

            Adresse adresse = new Adresse { Ligne1 = "8 rue du petit cheval", CodePostal = "12345", Ville = "Trifouilli", Pays = "Imaginaire" };
            Client c1 = new Client { Id = appUser1.Id, Adresse = adresse, Email = "toto@toto.fr", Nom = "Toto", Prenom = "Monsieur" };

            context.Clients.AddOrUpdate(c => c.Email, c1);
        }
    }
}
