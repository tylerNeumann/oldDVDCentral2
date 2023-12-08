﻿using System.ComponentModel;

namespace TN.DVDCentral.BL.Models
{
    public class User
    {
        public List<int> UserId { get; set; }
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string? FirstName { get; set; }
        [DisplayName("Last Name")]
        public string? LastName { get; set;}
        public string? UserName { get; set; }
        public string? Password { get; set; }
        [DisplayName("Full Name")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

    }
}
