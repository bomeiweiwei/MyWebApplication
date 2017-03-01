
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllShowConsoleApplication
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Database First，新增一個ADO.NET實體資料模型，並做查詢");
            using (AllShowEntities context = new AllShowEntities())
            {
                var query = from item in context.MEMBER
                            select new
                            {
                                memno = item.memno,
                                memname = item.memname
                            };
                foreach (var item in query)
                    Console.WriteLine("memno = {0} , memname = {1}", item.memno, item.memname);

                Console.ReadLine();
            }
        }
    }
}
