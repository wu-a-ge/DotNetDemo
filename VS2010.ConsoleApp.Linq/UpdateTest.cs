using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
namespace VS2010.ConsoleApp.Linq
{
    [TestFixture]
    class UpdateTest
    {
        [Test]
        public void UpdateWithVersion()
        {
            MyDbDataContext db = new MyDbDataContext();
            var t1 = db.t1.First();
            t1.name = "modified";
            db.SubmitChanges();
        }
    }
}
