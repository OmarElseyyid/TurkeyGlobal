using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkeyGlobal.BaseEntity;

namespace Entity.Entity
{
 public class Product:BaseEntity
    {

        public string Title { get; set; }
        public string Description{ get; set; }
        public string ShorDescription{ get; set; }
        public string File{ get; set; }

        public string Slug{ get; set; }
        public int Price{ get; set; }
        public int CurrencyTypeid{ get; set; }
        public CurrencyType CurrencyType { get; set; }
        public int Sellerid{ get; set; }
        public SellerInfo SellerInfo { get; set; }
        public int ProductCategoryID { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public virtual ICollection<ProductFile> ProductFiles { get; set; }
    }
}
