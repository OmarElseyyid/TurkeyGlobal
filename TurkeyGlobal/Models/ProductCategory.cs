using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkeyGlobal.BaseEntity;

namespace Entity.Entity
{
   public class ProductCategory :BaseEntity

    {
        public string Title { get; set; }
        public string Content{ get; set; }
        public string Slug{ get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
