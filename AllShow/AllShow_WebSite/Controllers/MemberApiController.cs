using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using AllShow_WebSite.Models;
using AllShow_WebSite.Models.member;

namespace AllShow_WebSite.Controllers
{
    public class MemberApiController : ApiController
    {

        // GET: api/MemberApi
        public IEnumerable<Member> Get()
        {
            AllShow db = new AllShow();
            var members = db.GetMember.Get();
            return members;//new string[] { "value1", "value2" };
        }

        // GET: api/MemberApi/5
        public Member Get(int id)
        {
            AllShow db = new AllShow();
            var member = db.GetMember.Get().Where(m => m.memno == id).FirstOrDefault();
            return member;
        }

        // POST: api/MemberApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MemberApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MemberApi/5
        public void Delete(int id)
        {
        }
    }
}
