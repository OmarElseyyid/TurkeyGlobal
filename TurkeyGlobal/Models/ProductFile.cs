using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkeyGlobal.BaseEntity;

namespace Entity.Entity
{
   public class ProductFile:BaseEntity
    {
        public string File { get; set; }
        public int Productid { get; set; }
        public Product Product { get; set; }
    }
}
