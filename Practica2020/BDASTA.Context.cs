﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Practica2020
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MagazineSetEntities : DbContext
    {
        public MagazineSetEntities()
            : base("name=MagazineSetEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Magazine> Magazine { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Единица_измерения> Единица_измерения { get; set; }
        public virtual DbSet<Отдел> Отдел { get; set; }
        public virtual DbSet<Отдел_товар> Отдел_товар { get; set; }
        public virtual DbSet<Продавец> Продавец { get; set; }
        public virtual DbSet<Продавец_Товар__Выручка_> Продавец_Товар__Выручка_ { get; set; }
        public virtual DbSet<Содержимое_чека> Содержимое_чека { get; set; }
        public virtual DbSet<Справочник__Улица> Справочник__Улица { get; set; }
        public virtual DbSet<Товар> Товар { get; set; }
        public virtual DbSet<Чек> Чек { get; set; }
    }
}
