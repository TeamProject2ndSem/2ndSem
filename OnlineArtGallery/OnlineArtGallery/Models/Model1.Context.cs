﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineArtGallery.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class galleryEntities1 : DbContext
    {
        public galleryEntities1()
            : base("name=galleryEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<inibuyer> inibuyers { get; set; }
        public virtual DbSet<reqacce> reqacces { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
    }
}
