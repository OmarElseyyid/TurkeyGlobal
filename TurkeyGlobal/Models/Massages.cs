using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkeyGlobal.BaseEntity;

namespace Entity.Entity
{
    public class Massages:BaseEntity
    {
        public int SenderId { get; set; }
        public int ReceverId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
