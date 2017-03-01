using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqStudyConsoleApplication
{
    class YieldTest
    {
        public static IEnumerable<int> GetCollections()
        {
            //List<int> list = new List<int>();

            for (int i = 0; i < 5; i++)
                yield return i;
            //{
            //    list.Add(i);
            //}
            //return list;

            for (int i = 5; i < 10; i++)
            {
                if (i == 9)
                    yield break;
                else
                    yield return i;
            }
        }
    }
}
