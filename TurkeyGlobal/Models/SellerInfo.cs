using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkeyGlobal.BaseEntity;

namespace Entity.Entity
{
    public class SellerInfo : BaseEntity
    {
        public int Userid { get; set; }
        public User user { get; set; }
        public string Sector { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}

