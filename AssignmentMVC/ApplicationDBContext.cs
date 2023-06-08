﻿using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AssignmentMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AssignmentMVC
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        private readonly string connection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AssignmentASPnet;Integrated Security=True;encrypt = false;";
        public ApplicationDBContext()
        {

        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)       //Will help us connect with database sqlserver
        {       
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(connection);
        }
        public DbSet<Product> Products { get; set; }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}
