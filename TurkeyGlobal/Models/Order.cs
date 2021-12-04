using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkeyGlobal.BaseEntity;

namespace Entity.Entity
{
    public class Order:BaseEntity
    {
        public int ProductCategoryid { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public string Description { get; set; }
        public int OfferPrice{ get; set; }
        public int CurrencyTypeid { get; set; }
        public CurrencyType CurrencyType { get; set; }

    }
}
