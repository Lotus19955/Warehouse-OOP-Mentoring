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
        static void Main(string[] args)
        {
            Warehouse sklad = AddInformation();
        }
        /// <summary>
        /// Create you own objects
        /// </summary>
        /// <returns>object</returns>
        public static Warehouse AddInformation()
        {
            Console.Write("Enter title of waherouse: ");
            string title = Console.ReadLine();

            Console.Write("Enter address of waherouse: ");
            string address = Console.ReadLine();

            Console.Write("Enter contuct number of waherouse: ");
            int contuctNumber = int.Parse(Console.ReadLine());

            Warehouse sklad = new Warehouse(title, address, contuctNumber);
            return sklad;
        }
    }
}