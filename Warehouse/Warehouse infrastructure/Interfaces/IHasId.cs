using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_infrastructure
{
    interface IHasId
    {
        Guid id { get; set; }
    }
}