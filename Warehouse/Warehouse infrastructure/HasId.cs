using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_infrastructure
{
    public class HasId
    {
        private Guid ID;
        public Guid id
        {
            get { return ID; }
            private set { ID = value; }
        }
        public HasId(Guid id)
        {
            this.ID = id;
        }
    }
}
