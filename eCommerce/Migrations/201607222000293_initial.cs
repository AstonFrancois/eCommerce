namespace eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Prenom = c.String(),
                        Nom = c.String(),
                        Email = c.String(),
                        Adresse_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Adresses", t => t.Adresse_Id)
                .Index(t => t.Adresse_Id);
            
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ligne1 = c.String(),
                        Ligne2 = c.String(),
                        CodePostal = c.String(),
                        Ville = c.String(),
                        Pays = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Commandes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Statut = c.Int(nullable: false),
                        ValidationDate = c.DateTime(nullable: false),
                        Adresse_Id = c.Int(),
                        Client_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Adresses", t => t.Adresse_Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .Index(t => t.Adresse_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.LigneCommandes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantite = c.Int(nullable: false),
                        Produit_Id = c.Int(),
                        Commande_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produits", t => t.Produit_Id)
                .ForeignKey("dbo.Commandes", t => t.Commande_Id)
                .Index(t => t.Produit_Id)
                .Index(t => t.Commande_Id);
            
            CreateTable(
                "dbo.Produits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Image = c.Binary(),
                        Description = c.String(),
                        PrixUnitaire = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stock = c.Int(nullable: false),
                        Categorie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Categorie_Id)
                .Index(t => t.Categorie_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.LigneCommandes", "Commande_Id", "dbo.Commandes");
            DropForeignKey("dbo.LigneCommandes", "Produit_Id", "dbo.Produits");
            DropForeignKey("dbo.Produits", "Categorie_Id", "dbo.Categories");
            DropForeignKey("dbo.Commandes", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Commandes", "Adresse_Id", "dbo.Adresses");
            DropForeignKey("dbo.Clients", "Adresse_Id", "dbo.Adresses");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Produits", new[] { "Categorie_Id" });
            DropIndex("dbo.LigneCommandes", new[] { "Commande_Id" });
            DropIndex("dbo.LigneCommandes", new[] { "Produit_Id" });
            DropIndex("dbo.Commandes", new[] { "Client_Id" });
            DropIndex("dbo.Commandes", new[] { "Adresse_Id" });
            DropIndex("dbo.Clients", new[] { "Adresse_Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Produits");
            DropTable("dbo.LigneCommandes");
            DropTable("dbo.Commandes");
            DropTable("dbo.Adresses");
            DropTable("dbo.Clients");
            DropTable("dbo.Categories");
        }
    }
}
