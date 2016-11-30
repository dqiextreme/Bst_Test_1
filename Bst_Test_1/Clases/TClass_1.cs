using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Bst_Test_1.Models;

namespace Bst_Test_1.Clases
{
    public class TClass_1
    {
        test_linqsql1Entities tlq = new test_linqsql1Entities();
        //Models.Adjunto adj = new Adjunto();
        

        public List<Adjunto> test()
        {
            List<Adjunto> ls = new List<Adjunto>();
            ls = tlq.Adjunto.ToList();
            return ls;
        }

        //public DbSet<Student> Students { get; set; }


        public void test2()
        {
            var adj = tlq.Adjunto;
            
       
            //var lkj = tlq.Set<Adjunto>();
            //lkj.Add(new Adjunto { Archivo = "archivo nuevo1", Ruta = "ruta nueva1" });
            //lkj.Add(new Adjunto { Archivo = "archivo nuevo2", Ruta = "ruta nueva2" });
            //lkj.Add(new Adjunto { Archivo = "archivo nuevo3", Ruta = "ruta nueva3" });

            //var lsn3 = new Adjunto { Archivo = "archivo nuevo", Ruta = "ruta nueva" };
            
            //tlq.Adjunto.Add(lsn3);

            //var poi = tlq.Adjunto.Single(x => x.ID == 1);
            var poi = adj.Single(x => x.ID == 1);
            poi.Archivo = "111Libro1NEW3.xlsx";
            poi.Ruta = "111Libro1NEW3.xlsx";

            

            tlq.SaveChanges();
            
        }

        public void local()
        {
            T3WEB_2012Entities db = new T3WEB_2012Entities();
            var a = db.T3TCOMPANY.ToList();
            var b = db.T3TCOMPANY.Single(x => x.ccompany == "S01");
        }
        
     
    }
}