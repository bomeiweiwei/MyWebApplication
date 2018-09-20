using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MVCStudy.Models;

namespace MVCStudy.Controllers
{
    public class ProductApiController : ApiController
    {
        AllShowEntities db = new AllShowEntities();

        // GET api/<controller>
        public List<PRODUCT> Get()
        {
            var products = db.PRODUCTs;
            return products.ToList();
        }

        // GET api/<controller>/5
        public PRODUCT Get(int proNo)
        {
            var product = db.PRODUCTs.Where(m => m.proNo == proNo).FirstOrDefault();
            return product;
        }

        // POST api/<controller>
        public int Post(string shNo, string proClassNo, string proName, string proPrice, string proState, string proPop)
        {
            int num = 0;
            try
            {
                PRODUCT product = new PRODUCT();
                product.shNo = Convert.ToInt32(shNo);
                product.proClassNo = Convert.ToInt32(proClassNo);
                product.proName = proName;
                product.proPrice = Convert.ToDouble(proPrice);
                product.proState = proState;
                product.proPop = proPop;
                product.proCreateDate = DateTime.Now;

                db.PRODUCTs.Add(product);
                num = db.SaveChanges();
            }
            catch (Exception)
            {
                num = 0;
            }
            return num;
        }

        // PUT api/<controller>/5
        public int Put(int proNo, string shNo, string proClassNo, string proName, string proPrice, string proState, string proPop)
        {
            int num = 0;
            try
            {
                var product = db.PRODUCTs.Where(m => m.proNo == proNo).FirstOrDefault();
                product.shNo =Convert.ToInt32( shNo);
                product.proClassNo = Convert.ToInt32(proClassNo);
                product.proName = proName;
                product.proPrice = Convert.ToDouble(proPrice);
                product.proState = proState;
                product.proPop = proPop;
                num = db.SaveChanges();
            }
            catch (Exception)
            {
                num = 0;
            }
            return num;
        }

        // DELETE api/<controller>/5
        public int Delete(int proNo)
        {
            int num = 0;
            try
            {
                var product = db.PRODUCTs.Where(m => m.proNo == proNo).FirstOrDefault();
                db.PRODUCTs.Remove(product);
                num = db.SaveChanges();
            }
            catch (Exception)
            {
                num = 0;
            }
            return num;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}