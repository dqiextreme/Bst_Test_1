using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bst_Test_1.Models;

namespace Bst_Test_1.Clases
{
    public class TClass_1
    {
        test_linqsql1Entities tlq = new test_linqsql1Entities();
        Models.Adjunto adj = new Adjunto();

        public List<Adjunto> test()
        {
            List<Adjunto> ls = new List<Adjunto>();
            ls = tlq.Adjunto.ToList();
            return ls;
        }
    }
}