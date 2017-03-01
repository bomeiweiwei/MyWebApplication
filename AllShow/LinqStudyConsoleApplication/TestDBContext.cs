using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace LinqStudyConsoleApplication
{
    class TestDBContext : DbContext
    {
        public TestDBContext() : base("TestDBContext")
        { }
        public DbSet<Testest> tests { get; set; }
    }
}
