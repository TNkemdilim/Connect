﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Connect.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ConnectOfflineDBEntities : DbContext
    {
        public ConnectOfflineDBEntities()
            : base("name=ConnectOfflineDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Account_Type_OfflineTable> Account_Type_OfflineTable { get; set; }
        public DbSet<Buyer_Details_OfflineTable> Buyer_Details_OfflineTable { get; set; }
        public DbSet<Sellers_Login_OfflineTable> Sellers_Login_OfflineTable { get; set; }
        public DbSet<User_Details_OfflineTable> User_Details_OfflineTable { get; set; }
    }
}
