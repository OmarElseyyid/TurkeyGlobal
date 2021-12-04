using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkeyGlobal.BaseEntity;

namespace Entity.Entity
{
    public class User:BaseEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }
        public string Password{ get; set; }
        public string Email { get; set; }
        public int Wallet { get; set; }
        public int UserRolid { get; set; }
        public UserRol UserRol { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<BuyerInfo> BuyerInfos { get; set; }
        public virtual ICollection<SellerInfo> SellerInfos { get; set; }
    }
}
