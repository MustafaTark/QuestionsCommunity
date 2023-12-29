﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Identity
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public Address Address { get; set; }
        
    }
}
