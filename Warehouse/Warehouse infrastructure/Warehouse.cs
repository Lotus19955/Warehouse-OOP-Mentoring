﻿using System;
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
        public int ContactNumber { get; set; }

        public Warehouse(string title, string address, int contactNumber)
        {
            this.Title = title;
            this.Address = address;
            this.ContactNumber = contactNumber;
        }
    }
}