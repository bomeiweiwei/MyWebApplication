using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;

namespace LinqStudyConsoleApplication
{
    delegate bool delmy(int num);
    class Program
    {
        delmy dm;
        delegate int mydel(int num);
        delegate int mydel2(int num1, int num2);
        delegate bool mydel3(int num1, int num2);
        static void Main(string[] args)
        {
            try
            {
                int money = 123456789;
                double d = 0.1581;
                Console.WriteLine("【擴充方法】");
                Console.WriteLine("{0}", money.FormatForMoney());//自設的擴充方法
                Console.WriteLine("{0}", d.FormatPercent());//自設的擴充方法
                Console.WriteLine("=======================================");
                Console.WriteLine("【讀取List】");
                List<Student> list = Student.GetStudents();
                foreach (Student student in list)
                {
                    Console.WriteLine("ID={0},name={1}", student.ID, student.name);
                }
                Console.WriteLine("=======================================");
                Console.WriteLine("【Yield 測試】");
                List<int> list2 = YieldTest.GetCollections().ToList();
                for (int i = 0; i < list2.Count; i++)
                {
                    Console.WriteLine("ID={0}", list2[i].ToString());
                }
                Console.WriteLine("=======================================");
                Console.WriteLine("【讀取List後，用Where篩選】");
                Console.WriteLine("use Where:");
                var query = list.Where(student => student.ID == "002");
                foreach (var student in query)
                {
                    Console.WriteLine("Name={0}", student.name);
                }
                //var query2 = list2.Where(c => c < 3);
                //foreach (var c in query2)
                //{
                //    Console.WriteLine("c={0}", c);
                //}
                Console.WriteLine("=======================================");
                Console.WriteLine("【讀取List後，用Where篩選，並new一個新的物件】");
                var _query = list.Where(student => student.ID == "002").Select(student => new
                {
                    ID = student.ID + "AA",
                    name = student.name + "BB"
                });
                foreach (var student in _query)
                {
                    Console.WriteLine("ID={0},Name={1}", student.ID, student.name);
                }
                Console.WriteLine("=======================================");
                Console.WriteLine("【讀取List後，使用GroupBY()和Group BY】");
                List<Student> _list = Student.GetStudents2();
                var _query2 = from stu in _list
                              group stu by stu.Location;
                foreach (var q in _query2)
                {
                    foreach (var student in q)
                        Console.WriteLine("ID={0},name={1},Location={2}", student.ID, student.name, student.Location);
                }
                Console.WriteLine("=====我是分隔線=====");
                _query2 = _list.GroupBy(o => o.Location);
                foreach (var q in _query2)
                {
                    Console.WriteLine("●Location：{0}", q.Key);
                    foreach (var student in q)
                        Console.WriteLine("ID={0},name={1},Location={2}", student.ID, student.name, student.Location);
                }
                Console.WriteLine("=======================================");
                Console.WriteLine("【ILookup】");
                var lookupValues = _list.ToLookup(o => o.Location);
                foreach (var q in lookupValues)
                {
                    Console.WriteLine("●Location：{0}", q.Key);
                    foreach (var student in q)
                        Console.WriteLine("ID={0},name={1}", student.ID, student.name);
                }
                Console.WriteLine("=======================================");
                Console.WriteLine("【Join】");
                LinqBase lb = new LinqBase();
                List<int> lbList = lb.getListJoin();
                foreach (int n in lbList)
                {
                    Console.WriteLine("n={0}", n);
                }
                List<StudentInfo> siList = lb.getListScoreJoin().ToList();
                foreach (StudentInfo si in siList)
                {
                    Console.WriteLine("● ID={0},name={1},ClassName={2},Score={3}", si.ID, si.name, si.ClassName, si.Score);
                }
                Console.WriteLine("=====我是分隔線=====");
                siList = lb.getListScoreLeftJoin().ToList();
                foreach (StudentInfo si in siList)
                {
                    Console.WriteLine("● ID={0},name={1},ClassName={2},Score={3}", si.ID, si.name, si.ClassName, si.Score);
                }
                Console.WriteLine("=======================================");
                int[] numA = { 0, 1, 3, 4, 5, 7, 8, 9 };
                int[] numB = { 1, 3, 5, 7, 8 };
                Console.WriteLine("●numA：" + string.Join(",", numA));
                Console.WriteLine("●numB：" + string.Join(",", numB));

                Console.WriteLine("【聯集】");
                var unionResult = numA.Union(numB);
                foreach (var q in unionResult)
                    Console.Write(q + ",");
                Console.WriteLine("");

                Console.WriteLine("【交集】");
                var intersectResult = numA.Intersect(numB);
                foreach (var q in intersectResult)
                    Console.Write(q + ",");
                Console.WriteLine("");

                Console.WriteLine("【補集】");
                var exceptResult = numA.Except(numB);
                foreach (var q in exceptResult)
                    Console.Write(q + ",");
                Console.WriteLine("");

                Console.WriteLine("=====我是分隔線=====");
                int[] numArr = { 4, 5, 5, 7, 5, 8, 5 };
                Console.WriteLine("●numArr：" + string.Join(",", numArr));

                Console.WriteLine("【Distinct】");
                var distinctResult = numArr.Distinct();
                foreach (var q in distinctResult)
                    Console.Write(q + ",");
                Console.WriteLine("");

                Console.WriteLine("=======================================");
                Console.WriteLine("【Lambda】");

                mydel del = x => x * 2;//指定參數為x,傳回x*2
                Console.WriteLine(del(5));

                del = x => { return x * x; };//指定參數為x,傳回x平方
                Console.WriteLine(del(5));

                mydel2 del2 = (x, y) => x * y;//指定參數為x、y,傳回x*y
                Console.WriteLine(del2(5, 7));

                mydel3 del3 = (x, y) => { return x == y; };//指定參數為x、y,傳回是否相等
                Console.WriteLine("Result:" + del3(5, 7));

                Console.WriteLine("=====我是分隔線=====");

                Program p = new Program();
                p.test(10);
                bool result = p.dm(5);
                Console.WriteLine("result:" + result);

                Console.WriteLine("=======================================");
                using (SqlConnection Conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=test;User ID=dbtest;Password=dbtest0000"))
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT [id], [title], [summary], [test_time] FROM [test]", Conn);

                    DataSet ds = new DataSet();

                    try
                    {

                        da.Fill(ds, "myTable");
                        DataTable dataTable = new DataTable();
                        dataTable = ds.Tables["myTable"];

                        IEnumerable<DataRow> myQuery = from test in dataTable.AsEnumerable()
                                                       where test.Field<DateTime>("test_time") > new DateTime(2015, 7, 13)
                                                       select test;

                        foreach (var q in myQuery)
                            Console.WriteLine("標題：" + q.Field<string>("title"));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message.ToString());
                    }
                }
                Console.WriteLine("Database First，新增一個ADO.NET實體資料模型，並做查詢");
                using (testEntities context = new testEntities())
                {
                    var queryTest = from item in context.tests
                                    .Where(c => c.test_time > new DateTime(2015, 7, 13))
                                    select new
                                    {
                                        title = item.title,
                                        @class = item.@class
                                    };
                    foreach (var item in queryTest)
                        Console.WriteLine("title = {0} , class = {1}", item.title, item.@class);
                                        
                }

                Console.WriteLine("=======================================");
                Console.WriteLine("自已設定類別(參考資料庫Table, using System.Data.Linq.Mapping)、使用DataContext");
                using (SqlConnection Conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=test;User ID=dbtest;Password=dbtest0000"))
                {
                    using (DataContext dc = new DataContext(Conn))
                    {
                        Table<Student_Test> tests = dc.GetTable<Student_Test>();
                        var queryTest = from item in tests
                                       .Where(c => c.city == "台北市")
                                        select new
                                        {
                                            name = item.name,
                                            chinese = item.chinese,
                                            math = item.math
                                        };
                        foreach (var item in queryTest)
                            Console.WriteLine("name = {0} , chinese = {1} , math = {2}", item.name, item.chinese, item.math);
                    }
                }
                Console.WriteLine("=====我是分隔線=====");
                using (SqlConnection Conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=test;User ID=dbtest;Password=dbtest0000"))
                {
                    using (DataContext dc = new DataContext(Conn))
                    {
                        var tests = dc.ExecuteQuery<Student_Test>("select * from student_test where city = {0}", "台北市");
                        foreach (var item in tests)
                            Console.WriteLine("name = {0} , chinese = {1} , math = {2}", item.name, item.chinese, item.math);
                    }
                }
                Console.WriteLine("=======================================");
                Console.WriteLine("自已設定類別(參考資料庫Table, using System.ComponentModel.DataAnnotations.Schema)、設定xxDBContext、config設定連線");
                using (TestDBContext tContext = new TestDBContext())
                {
                    Testest testest = tContext.tests.Find(3);
                    if (testest != null)
                    {
                        Console.WriteLine("查詢到的test, title = {0} , class = {1}", testest.title, testest.@class);
                    }
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadLine();
        }

        public void test(int num)
        {
            dm = (x) => { return x == num; };
        }
    }
}
