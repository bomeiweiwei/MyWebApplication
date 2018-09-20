using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using MVCStudy.Models.shop;

namespace MVCStudy.Models
{
    public class AllShow
    {        
        private IDataOperation<SHOP> _shop = null;//              

        public IDataOperation<SHOP> GetShop
        {
            get
            {
                if (this._shop == null)
                {
                    this._shop = new ShopDataOperation();
                }
                return this._shop;
            }
        }        
    }

    public class AllShowDbContext : DbContext
    {
        public DbSet<MVCStudy.Models.employee.Employee> Emps { get; set; }
    }
}