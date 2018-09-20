using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using AllShowMVCApplication.Models.authority;
using AllShowMVCApplication.Models.favoriteshoplist;

namespace AllShowMVCApplication.Models
{
    public class AllShowContext:DbContext
    {
        public AllShowContext()
            : base("name=AllShowDBContext")
        { }

        public DbSet<Authority> Authorities { get; set; }
        public DbSet<Favoriteshoplist> Favoriteshoplistes { get; set; }
    }
}