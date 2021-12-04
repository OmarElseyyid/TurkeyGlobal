using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkeyGlobal.BaseEntity;


namespace Entity.Entity
{
    public class UserRol : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }

    }
}
