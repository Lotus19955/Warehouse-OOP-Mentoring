using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_infrastructure
{
    public class HasId
    {
        public Guid id {get; set;}
        public HasId() 
        {
            this.id = Guid.NewGuid();
        }
    }
}
