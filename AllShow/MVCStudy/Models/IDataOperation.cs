using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCStudy.Models
{
    public interface IDataOperation<T> where T : class,new()
    {
        IEnumerable<T> Get();
        T FindOne(int id);
        void Create(T Item);
        void Update(T Item);
        void Delete(T Item);
    }
}