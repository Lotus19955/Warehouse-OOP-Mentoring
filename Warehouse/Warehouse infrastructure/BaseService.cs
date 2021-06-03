using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_infrastructure
{
    public class BaseService
    {
        public virtual void Create() {}
        public virtual void UpdateInformation(Warehouse garage) { }
        public virtual void Display(Warehouse garage) { }
    }
}
