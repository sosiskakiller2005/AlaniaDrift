﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AlaniaDrift.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AlaniaDriftDbEntities : DbContext
    {
        public AlaniaDriftDbEntities()
            : base("name=AlaniaDriftDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Body> Body { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<Documents> Documents { get; set; }
        public DbSet<Model> Model { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Track> Track { get; set; }
    }
}
