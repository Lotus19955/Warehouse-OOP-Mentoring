using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_infrastructure
{
    public class HasId
    {
        private Guid id;
        public Guid ID
        {
            get { return id; }
            private set { id = value; }
        }
        public HasId(Guid ID)
        {
            this.id = ID;
        }
    }
}
