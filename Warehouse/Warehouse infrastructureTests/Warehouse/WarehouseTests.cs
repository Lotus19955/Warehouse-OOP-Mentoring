using Microsoft.VisualStudio.TestTools.UnitTesting;
using Warehouse_infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_infrastructure.Tests
{
    [TestClass()]
    public class WarehouseTests
    {
        [TestMethod()]
        public void UpdateVacancyTest()
        {
            //arrange
            int vacancy = 0;
            int number = 5;
            int expected = 5;
            Dictionary<string, List<Message>> mailBox = new Dictionary<string, List<Message>>();

            //act
            Warehouse x = new Warehouse("Home", "Minsk", "12345678", vacancy, mailBox);
            x.UpdateVacancy(number);
            int actual = x.Number_of_vacancy;

            //assert
            Assert.AreEqual(expected, actual);
        }
        public void DisplayTest()
        {
            // arrange
            string country = "Belarus";

            //act
            WarehouseService warehouseService = new WarehouseService();
            warehouseService.Display(country, country);

            //assert
            
        }
    }
}