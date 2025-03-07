﻿using Microsoft.EntityFrameworkCore;

namespace newmachinetest.Models
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions options) : base(options)
        {


        }
        public DbSet<Product> productss { get; set; }
    }
}
