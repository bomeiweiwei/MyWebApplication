﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace AllShowConsoleApplication
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AllShowEntities : DbContext
    {
        public AllShowEntities()
            : base("name=AllShowEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ADVERTISEMENT> ADVERTISEMENT { get; set; }
        public virtual DbSet<ANNOUNCEMENT> ANNOUNCEMENT { get; set; }
        public virtual DbSet<AUTHORITYFUNCTION> AUTHORITYFUNCTION { get; set; }
        public virtual DbSet<EMPLOYEE> EMPLOYEE { get; set; }
        public virtual DbSet<MEMBER> MEMBER { get; set; }
        public virtual DbSet<MEMBERLIST> MEMBERLIST { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<ORDERLIST> ORDERLIST { get; set; }
        public virtual DbSet<PRODUCT> PRODUCT { get; set; }
        public virtual DbSet<PRODUCTCLASS> PRODUCTCLASS { get; set; }
        public virtual DbSet<SHCLASS> SHCLASS { get; set; }
        public virtual DbSet<SHOP> SHOP { get; set; }
        public virtual DbSet<SHOPORDER> SHOPORDER { get; set; }
    }
}