using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using AllShow_WebSite.Models;
using AllShow_WebSite.Models.favoriteshoplist;
using AllShow_WebSite.Models.member;
using AllShow_WebSite.Models.shop;

namespace AllShow_WebSite.Controllers
{
    public class FavoriteshoplistApiController : ApiController
    {
       
        // GET: api/FavoriteshoplistApi
        public List<Shop> Get()
        {
            AllShow db = new AllShow();
            bool check = RequestContext.Principal.Identity.IsAuthenticated;
            if (check)
            {
                var favoriteshoplists = db.GetFavoriteshoplist.Get();
                List<Shop> shopList = new List<Shop>();
                foreach (var favor in favoriteshoplists)
                {
                    Shop shop = db.GetShop.FindOne(favor.shNo);
                    Shop _shop = new Shop()
                    {
                        shno = shop.shno,
                        shlogopic = shop.shlogopic != null && shop.shlogopic != "" ? shop.shlogopic : "NoShop.png",
                        shname = shop.shname
                    };
                    shopList.Add(_shop);
                }

                return shopList;
            }
            else
            {
                return Enumerable.Empty<Shop>().ToList();
            }
        }

        // GET: api/FavoriteshoplistApi/5
        public Favoriteshoplist Get(int memno,int shno)
        {
            AllShow db = new AllShow();
            Favoriteshoplist favoriteshoplist = new Favoriteshoplist();
            bool check = RequestContext.Principal.Identity.IsAuthenticated;
            if (check)
            {
                string userInfo = RequestContext.Principal.Identity.Name;
                favoriteshoplist = db.GetFavoriteshoplist.Get().Where(m => m.shNo == shno && m.memNo == memno).FirstOrDefault();
                return favoriteshoplist;
            }
            else
            {
                return favoriteshoplist; 
            }
        }

        // POST: api/FavoriteshoplistApi
        public int Post(int shno)
        {
            AllShow db = new AllShow();
            int result = 1;//新增成功
            bool check = RequestContext.Principal.Identity.IsAuthenticated;
            try
            {
                if (check)
                {
                    Member member = db.GetMember.Get().Where(m => m.mememail == RequestContext.Principal.Identity.Name).FirstOrDefault();

                    //FavoriteshoplistDataOperation fDO = new FavoriteshoplistDataOperation();
                    //Favoriteshoplist check = fDO.FindOne(memno, shno);
                    Favoriteshoplist _favoriteshoplist = db.GetFavoriteshoplist.Get().Where(m => m.shNo == shno && m.memNo == member.memno).FirstOrDefault();
                    if (_favoriteshoplist == null)
                    {
                        Favoriteshoplist favoriteshoplist = new Favoriteshoplist()
                        {
                            memNo = member.memno,
                            shNo = shno
                        };
                        db.GetFavoriteshoplist.Create(favoriteshoplist);
                    }
                    else
                        result = 0;//新增失敗，已經存在
                }
                else
                    result = 0;//未登入
            }
            catch (Exception)
            {
                result = 0;
            }
            return result;
        }

        // PUT: api/FavoriteshoplistApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FavoriteshoplistApi/5
        public int Delete(int id)
        {
            AllShow db = new AllShow();
            int result = 1;//刪除成功
            bool check = RequestContext.Principal.Identity.IsAuthenticated;
            try
            {
                if (check)
                {
                    Member member = db.GetMember.Get().Where(m => m.mememail == RequestContext.Principal.Identity.Name).FirstOrDefault();

                    Favoriteshoplist _favoriteshoplist = db.GetFavoriteshoplist.Get().Where(m => m.shNo == id && m.memNo == member.memno).FirstOrDefault();
                    if (_favoriteshoplist != null)
                    {
                        db.GetFavoriteshoplist.Delete(_favoriteshoplist);
                    }
                    else
                        result = 0;
                }
                else
                    result = 0;//未登入
            }
            catch (Exception)
            {
                result = 0;
            }
            return result;
        }
    }
}
