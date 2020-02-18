﻿using Hbsis.Ambev.Unicesumar.Canteen.Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Hbsis.Ambev.Unicesumar.Canteen.Infra
{
    public class CanteenContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public CanteenContext(IConfiguration configuration) { _configuration = configuration; }

        public CanteenContext(DbContextOptions<CanteenContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new OrderMapping());
            modelBuilder.ApplyConfiguration(new OrderProductMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}