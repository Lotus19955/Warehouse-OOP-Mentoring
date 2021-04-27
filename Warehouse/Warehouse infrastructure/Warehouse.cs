using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_infrastructure
{
    public class Warehouse
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public int ContuctNumber { get; set; }

        public Warehouse(string title, string address, int contuctNumber)
        {
            this.Title = title;
            this.Address = address;
            this.ContuctNumber = contuctNumber;
        }
        /// <summary>
        /// Display to console warehouse 'title'
        /// </summary>
        public void DisplayTitle(Warehouse displayInformation)
        {
            Console.WriteLine($"Warehouse title: '{displayInformation.Title}'");
        }
        /// <summary>
        /// Display to console warehouse 'adress'
        /// </summary>
        public void DisplayAddress(Warehouse displayInformation)
        {
            Console.WriteLine($"Warehouse address: {displayInformation.Address}");
        }
        /// <summary>
        /// Display to console warehouse 'contuct number'
        /// </summary>
        public void DisplayContuctNumber(Warehouse displayContuctNumber)
        {
            Console.WriteLine($"Warehouse contuct number: {displayContuctNumber.ContuctNumber}");
        }
    }
}