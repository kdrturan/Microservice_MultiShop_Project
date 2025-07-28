﻿using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Context
{
    public class CommentContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1436;initial catalog=MultiShopCargoDb;TrustServerCertificate=true;User=sa;Password=123456789Aa*");
        }

        public DbSet<UserComment> UserComments { get; set; }
    }
}
