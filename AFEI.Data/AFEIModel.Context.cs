﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AFEI.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using AFEI.Models;
    
    
    public partial class AFEIEntities : DbContext
    {
        public AFEIEntities()
            : base("name=AFEIEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ChangesLog> ChangesLogs { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
