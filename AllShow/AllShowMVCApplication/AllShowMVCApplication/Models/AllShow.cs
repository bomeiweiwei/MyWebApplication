﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AllShowMVCApplication.Models.authority;
using AllShowMVCApplication.Models.favoriteshoplist;
using AllShowMVCApplication.Models.authorityfunction;
using AllShowMVCApplication.Models.employee;
using AllShowMVCApplication.Models.announcement;
using AllShowMVCApplication.Models.shop;
using AllShowMVCApplication.Models.advertisement;
using AllShowMVCApplication.Models.shclass;
using AllShowMVCApplication.Models.productclass;
using AllShowMVCApplication.Models.product;
using AllShowMVCApplication.Models.member;
using AllShowMVCApplication.Models.memberlist;
using AllShowMVCApplication.Models.shoporder;
using AllShowMVCApplication.Models.orderlist;

namespace AllShowMVCApplication.Models
{
    public class AllShow
    {
        private IDataOperation<AUTHORITYFUNCTION> _authorityfunction = null;//
        private IDataOperation<EMPLOYEE> _employee = null;//
        private IDataOperation<Authority> _authority = null;//
        private IDataOperation<ANNOUNCEMENT> _announcement = null;//
        private IDataOperation<SHOP> _shop = null;//
        private IDataOperation<ADVERTISEMENT> _advertisement = null;//
        private IDataOperation<SHCLASS> _shclass = null;//
        private IDataOperation<PRODUCTCLASS> _productclass = null;//
        private IDataOperation<PRODUCT> _product = null;//
        private IDataOperation<MEMBER> _member = null;//
        private IDataOperation<Favoriteshoplist> _favoriteshoplist = null;//
        private IDataOperation<MEMBERLIST> _memberlist = null;//
        private IDataOperation<SHOPORDER> _shoporder = null;//
        private IDataOperation<ORDERLIST> _orderlist = null;//

        public IDataOperation<AUTHORITYFUNCTION> GetAuthorityfunction
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

        public IDataOperation<EMPLOYEE> GetEmployee
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

        public IDataOperation<Authority> GetAuthority
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

        public IDataOperation<ANNOUNCEMENT> GetAnnouncement
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

        public IDataOperation<ADVERTISEMENT> GetAdvertisement
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

        public IDataOperation<SHCLASS> GetShclass
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

        public IDataOperation<PRODUCTCLASS> GetProductclass
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

        public IDataOperation<PRODUCT> GetProduct
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

        public IDataOperation<MEMBER> GetMember
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

        public IDataOperation<Favoriteshoplist> GetFavoriteshoplist
        {
            get
            {
                if (this._favoriteshoplist == null)
                {
                    this._favoriteshoplist = new FavoriteShopListDataOperation();
                }
                return this._favoriteshoplist;
            }
        }

        public IDataOperation<MEMBERLIST> GetMemberlist
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

        public IDataOperation<SHOPORDER> GetShoporder
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

        public IDataOperation<ORDERLIST> GetOrderlist
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

        #region Create
        public void CreateAuthorityfunction(AUTHORITYFUNCTION authorityfunction)
        { }

        public void CreateEmployee(EMPLOYEE employee)
        { }

        public void CreateAuthority(Authority authority)
        { }

        public void CreateShop(SHOP shop)
        { }

        public void CreateAdvertisement(ADVERTISEMENT advertisement)
        { }

        public void CreateShclass(SHCLASS shclass)
        { }

        public void CreateProductclass(PRODUCTCLASS productclass)
        { }

        public void CreateProduct(PRODUCT product)
        { }

        public void CreateMember(MEMBER member)
        { }

        public void CreateFavoriteshoplist(Favoriteshoplist favoriteshoplist)
        { }

        public void CreateMemberlist(MEMBERLIST memberlist)
        { }

        public void CreateShoporder(SHOPORDER shoporder)
        { }

        public void CreateOrderlist(ORDERLIST orderlist)
        { }
        #endregion

        #region Update
        public void UpdateAuthorityfunction(AUTHORITYFUNCTION authorityfunction)
        { }

        public void UpdateEmployee(EMPLOYEE employee)
        { }

        public void UpdateAuthority(Authority authority)
        { }

        public void UpdateShop(SHOP shop)
        { }

        public void UpdateAdvertisement(ADVERTISEMENT advertisement)
        { }

        public void UpdateShclass(SHCLASS shclass)
        { }

        public void UpdateProductclass(PRODUCTCLASS productclass)
        { }

        public void UpdateProduct(PRODUCT product)
        { }

        public void UpdateMember(MEMBER member)
        { }

        public void UpdateFavoriteshoplist(Favoriteshoplist favoriteshoplist)
        { }

        public void UpdateMemberlist(MEMBERLIST memberlist)
        { }

        public void UpdateOrderlist(ORDERLIST orderlist)
        { }
        #endregion

        #region Delete
        public void DeleteAuthorityfunction(AUTHORITYFUNCTION authorityfunction)
        { }

        public void DeleteEmployee(EMPLOYEE employee)
        { }

        public void DeleteAuthority(Authority authority)
        { }

        public void DeleteShop(SHOP shop)
        { }

        public void DeleteAdvertisement(ADVERTISEMENT advertisement)
        { }

        public void DeleteShclass(SHCLASS shclass)
        { }

        public void DeleteProductclass(PRODUCTCLASS productclass)
        { }

        public void DeleteProduct(PRODUCT product)
        { }

        public void DeleteMember(MEMBER member)
        { }

        public void DeleteFavoriteshoplist(Favoriteshoplist favoriteshoplist)
        { }

        public void DeleteMemberlist(MEMBERLIST memberlist)
        { }

        public void DeleteOrderlist(ORDERLIST orderlist)
        { }
        #endregion
    }
}