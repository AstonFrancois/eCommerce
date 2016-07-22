using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Business
{
    public class Produit
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public byte[] Image { get; set; }
        public Categorie Categorie { get; set; }
        public string Description { get; set; }
        public decimal PrixUnitaire { get; set; }
        public int Stock { get; set; }
    }
}
