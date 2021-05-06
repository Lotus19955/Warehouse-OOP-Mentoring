using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_infrastructure;

namespace WarehouseOOPMentoring
{
    class Program
    {
        private static void Main(string[] args)
        {
            WarehouseService.CreateObject();
            WarehouseService.Menu();
            Console.ReadLine();
        }
    }
}