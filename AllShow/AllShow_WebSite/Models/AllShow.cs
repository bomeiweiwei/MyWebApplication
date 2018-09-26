using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AllShow_WebSite.Models.member;
using AllShow_WebSite.Models.announcement;
using AllShow_WebSite.Models.advertisement;
using AllShow_WebSite.Models.shclass;
using AllShow_WebSite.Models.shop;
using AllShow_WebSite.Models.favoriteshoplist;
using AllShow_WebSite.Models.productclass;
using AllShow_WebSite.Models.product;

namespace AllShow_WebSite.Models
{
    public class AllShow
    {
        private IDataOperation<Member> _member = null;//
        private IDataOperation<Announcement> _announcement = null;//
        private IDataOperation<Advertisement> _advertisement = null;//
        private IDataOperation<Shclass> _shclass = null;//
        private IDataOperation<Shop> _shop = null;//
        private IDataOperation<Favoriteshoplist> _favoriteshoplist = null;//
        private IDataOperation<Productclass> _productclass = null;//
        private IDataOperation<Product> _product = null;//

        public IDataOperation<Member> GetMember
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

        public IDataOperation<Announcement> GetAnnouncement
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

        public IDataOperation<Advertisement> GetAdvertisement
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

        public IDataOperation<Shclass> GetShclass
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

        public IDataOperation<Shop> GetShop
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

        public IDataOperation<Favoriteshoplist> GetFavoriteshoplist
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

        public IDataOperation<Productclass> GetProductclass
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

        public IDataOperation<Product> GetProduct
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
    }
}