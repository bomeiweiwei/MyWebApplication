using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MVCStudy.Models;

namespace MVCStudy.Controllers
{
    public class ProductClassApiController : ApiController
    {
        AllShowEntities db = new AllShowEntities();
        // GET: api/ProductClassApi
        public IEnumerable<PRODUCTCLASS> Get()
        {
            var productclasses = db.PRODUCTCLASSes;
            return productclasses;
        }

        public IEnumerable<PRODUCTCLASS> Get(int shNo)
        {
            var productclasses = db.PRODUCTCLASSes.Where(m => m.shno == shNo);
            return productclasses;
        }

        // GET: api/ProductClassApi/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/ProductClassApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ProductClassApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ProductClassApi/5
        public void Delete(int id)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}
