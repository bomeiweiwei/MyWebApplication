using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqStudyConsoleApplication
{
    class LinqBase
    {
        public List<int> getListJoin()
        {
            List<int> list1 = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            List<int> list2 = new List<int>() { 5, 6, 7, 8, 9, 10, 11 };
            List<int> ResultList = new List<int>();
            var query = from item1 in list1
                        join item2 in list2 on item1 equals item2
                        select item2;

            foreach (var num in query)
            {
                ResultList.Add(num);
            }

            return ResultList;
        }

        public IEnumerable<StudentInfo> getListScoreJoin()
        {
            List<StudentInfo> ResultList = new List<StudentInfo>();
            List<Student> list1 = new List<Student>
            {
                new Student(){ID="001",name="小王",Location="A"},
                new Student(){ID="002",name="小明",Location="B"},
                new Student(){ID="003",name="小楊",Location="B"}
            };

            List<StudentClassScore> list2 = new List<StudentClassScore>
            {
                new StudentClassScore(){SID="001",ClassName="math",Score=60},
                new StudentClassScore(){SID="002",ClassName="math",Score=80},
                new StudentClassScore(){SID="003",ClassName="math",Score=100},
                new StudentClassScore(){SID="001",ClassName="english",Score=80},
                new StudentClassScore(){SID="002",ClassName="english",Score=70},
                new StudentClassScore(){SID="001",ClassName="chinese",Score=90},
                new StudentClassScore(){SID="003",ClassName="chinese",Score=60}
            };

            var query = from item1 in list1
                        join item2 in list2 on item1.ID equals item2.SID
                        select new { item1.ID, item1.name, item2.ClassName, item2.Score};

            foreach (var data in query)
            {
                StudentInfo si = new StudentInfo(data.ID, data.name, data.ClassName, data.Score);
                yield return si;
            }
        }

        public IEnumerable<StudentInfo> getListScoreLeftJoin()
        {
            List<StudentInfo> ResultList = new List<StudentInfo>();
            List<Student> list1 = new List<Student>
            {
                new Student(){ID="001",name="小王",Location="A"},
                new Student(){ID="002",name="小明",Location="B"},
                new Student(){ID="003",name="小楊",Location="B"},
                new Student(){ID="004",name="小張",Location="C"},
                new Student(){ID="005",name="小香",Location="D"}
            };

            List<StudentClassScore> list2 = new List<StudentClassScore>
            {
                new StudentClassScore(){SID="001",ClassName="math",Score=60},
                new StudentClassScore(){SID="002",ClassName="math",Score=80},
                new StudentClassScore(){SID="003",ClassName="math",Score=100},
                new StudentClassScore(){SID="001",ClassName="english",Score=80},
                new StudentClassScore(){SID="002",ClassName="english",Score=70},
                new StudentClassScore(){SID="001",ClassName="chinese",Score=90},
                new StudentClassScore(){SID="003",ClassName="chinese",Score=60}
                //new StudentClassScore(){SID="004",ClassName="chinese",Score=60},
                //new StudentClassScore(){SID="005",ClassName="chinese",Score=60}
            };
            try
            {
                var defalutSCS = new StudentClassScore();
                var query = from item1 in list1
                            join item2 in list2 on item1.ID equals item2.SID into ps
                            from item2 in ps.DefaultIfEmpty(defalutSCS)
                            select new
                            {
                                _ID = item1.ID,
                                _name = item1.name,
                                _ClassName = item2.ClassName,
                                _Score = item2.Score//(item2.Score >= 0 ? item2.Score : new Nullable<int>())
                            };

                foreach (var data in query)
                {
                    StudentInfo si = new StudentInfo(data._ID, data._name, data._ClassName, data._Score);
                    ResultList.Add(si);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return ResultList;
        }
    }

    class StudentInfo
    {
        public string ID { get; set; }
        public string name { get; set; }
        public string ClassName { get; set; }
        public int? Score { get; set; }
        public StudentInfo(string ID, string name, string ClassName, int? Score)
        {
            this.ID = ID;
            this.name = name;
            this.ClassName = ClassName;
            this.Score = Score;
        }
    }
}
