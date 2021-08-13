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
    public class EmployeeTest
    {
        [TestMethod()]

        public void SortEmployeeByAgeTest()
        {
            //arrange
            int[] noSortArray = new int[] { 8, 11, 1, 5, 66, 13, 20 };
            int[] expectedSortArray = new int[] { 1, 5, 8, 11, 13, 20, 66 };

            //act
            EmployeeService employeeService = new EmployeeService();
            employeeService.SortEmployeeByAge<int>(noSortArray);

            //assert
            CollectionAssert.AreEqual(noSortArray, expectedSortArray);
        }
    }
}

