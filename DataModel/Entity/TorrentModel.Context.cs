﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Torrent_dbEntities : DbContext
    {
        public Torrent_dbEntities()
            : base("name=Torrent_dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Characteristic> Characteristics { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Torrent> Torrents { get; set; }
        public virtual DbSet<TorrentCharacteristic> TorrentCharacteristics { get; set; }
        public virtual DbSet<TorrentType> TorrentTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<TorrentFile> TorrentFiles { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<PrivateMessage> PrivateMessages { get; set; }
        public virtual DbSet<MessageTitle> MessageTitles { get; set; }
    }
}