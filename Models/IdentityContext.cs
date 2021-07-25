﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebShop.Models
{
    public class IdentityContext : IdentityDbContext<MyUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options) { }
    }
}
