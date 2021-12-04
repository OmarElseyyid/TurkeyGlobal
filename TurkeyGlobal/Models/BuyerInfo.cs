using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkeyGlobal.BaseEntity;

namespace Entity.Entity
{
    public class BuyerInfo:BaseEntity
    {
        public int Userid { get; set; }
        public User User { get; set; }
    }
}
