using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AllShow.Models.authority;
using AllShow.Models.favoriteshoplist;
using AllShow.Models.authorityfunction;
using AllShow.Models.employee;
using AllShow.Models.announcement;
using AllShow.Models.shop;
using AllShow.Models.advertisement;
using AllShow.Models.shclass;
using AllShow.Models.productclass;
using AllShow.Models.product;
using AllShow.Models.member;
using AllShow.Models.memberList;
using AllShow.Models.shoporder;
using AllShow.Models.orderList;

namespace AllShow.Models
{
    public class AllShow
    {
        private IDataOperation<AuthorityFunction> _authorityfunction = null;//
        private IDataOperation<Employee> _employee = null;//
        private IDataOperation<Authority> _authority = null;//
        private IDataOperation<Announcement> _announcement = null;//
        private IDataOperation<Shop> _shop = null;//
        private IDataOperation<Advertisement> _advertisement = null;//
        private IDataOperation<Shclass> _shclass = null;//
        private IDataOperation<Productclass> _productclass = null;//
        private IDataOperation<Product> _product = null;//
        private IDataOperation<Member> _member = null;//
        private IDataOperation<Favoriteshoplist> _favoriteshoplist = null;//
        private IDataOperation<Memberlist> _memberlist = null;//
        private IDataOperation<Shoporder> _shoporder = null;//
        private IDataOperation<Orderlist> _orderlist = null;//

        public IDataOperation<AuthorityFunction> Authorityfunction
        {
            get
            {
                if (this._authorityfunction == null)
                {
                    this._authorityfunction = new AuthorityFunctionDataOperation();
                }
                return this._authorityfunction;
            }
        }

        public IDataOperation<Employee> Employee
        {
            get
            {
                if (this._employee == null)
                {
                    this._employee = new EmployeeDataOperation();
                }
                return this._employee;
            }
        }

        public IDataOperation<Authority> Authority
        {
            get
            {
                if (this._authority == null)
                {
                    this._authority = new AuthorityDataOperation();
                }
                return this._authority;
            }
        }

        public IDataOperation<Announcement> Announcement
        {
            get
            {
                if (this._announcement == null)
                {
                    this._announcement = new AnnouncementDataOperation();
                }
                return this._announcement;
            }
        }

        public IDataOperation<Shop> Shop
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

        public IDataOperation<Advertisement> Advertisement
        {
            get
            {
                if (this._advertisement == null)
                {
                    this._advertisement = new AdvertisementDataOperation();
                }
                return this._advertisement;
            }
        }

        public IDataOperation<Shclass> Shclass
        {
            get
            {
                if (this._shclass == null)
                {
                    this._shclass = new ShclassDataOperation();
                }
                return this._shclass;
            }
        }

        public IDataOperation<Productclass> Productclass
        {
            get
            {
                if (this._productclass == null)
                {
                    this._productclass = new ProductclassDataOperation();
                }
                return this._productclass;
            }
        }

        public IDataOperation<Product> Product
        {
            get
            {
                if (this._product == null)
                {
                    this._product = new ProductDataOperation();
                }
                return this._product;
            }
        }

        public IDataOperation<Member> Member
        {
            get
            {
                if (this._member == null)
                {
                    this._member = new MemberDataOperation();
                }
                return this._member;
            }
        }

        public IDataOperation<Favoriteshoplist> Favoriteshoplist
        {
            get
            {
                if (this._favoriteshoplist == null)
                {
                    this._favoriteshoplist = new FavoriteshoplistDataOperation();
                }
                return this._favoriteshoplist;
            }
        }

        public IDataOperation<Memberlist> Memberlist
        {
            get
            {
                if (this._memberlist == null)
                {
                    this._memberlist = new MemberlistDataOperation();
                }
                return this._memberlist;
            }
        }

        public IDataOperation<Shoporder> Shoporder
        {
            get
            {
                if (this._shoporder == null)
                {
                    this._shoporder = new ShoporderDataOperation();
                }
                return this._shoporder;
            }
        }

        public IDataOperation<Orderlist> Orderlist
        {
            get
            {
                if (this._orderlist == null)
                {
                    this._orderlist = new OrderlistDataOperation();
                }
                return this._orderlist;
            }
        }
    }
}