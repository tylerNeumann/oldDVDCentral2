﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int UserId { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? ZIP { get; set; }
        public string? Phone { get; set; }
        public string? ImagePath { get; set; }  
    }
}
