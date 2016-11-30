using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Transactions;
using System.Web;
using Bst_Test_1.Models;




namespace Bst_Test_1.Clases
{
    public class TClass_2
    {
        test_linqsql1Entities DB_Entity = new test_linqsql1Entities();
        
        public List<Adjunto> test()
        {
            List<Adjunto> ls = new List<Adjunto>();
            ls = DB_Entity.Adjunto.ToList();
            return ls;
        }

        public List<Adjunto> master(int id)
        {
            var res = ts();
            //var a = DB_Entity.Adjunto.Where(x => x.ID == 1).ToList().DefaultIfEmpty(new Adjunto()).ToList();
            return DB_Entity.Adjunto.Where(x => x.ID == id).ToList().DefaultIfEmpty(new Adjunto()).ToList();
        }

        public List<Adjunto> ts()
        {
            return DB_Entity.Adjunto.Where(x => x.ID == 1).ToList().DefaultIfEmpty(new Adjunto()).ToList();
        }


        //--------------------------------DELETE-------
        public void delete_simple1()
        {
            Adjunto rem = DB_Entity.Adjunto.Single(x => x.ID == 7043);
            DB_Entity.Adjunto.Remove(rem);
            DB_Entity.SaveChanges();
        }

        public void delete_simple2()
        {
            List<Adjunto> rem = DB_Entity.Adjunto.Where(x => x.ID >= 7036).ToList();
            rem.ForEach(x => DB_Entity.Adjunto.Remove(x));
            DB_Entity.SaveChanges();
        }
        //--------------------------------DELETE-------
        
        //--------------------------------UPDATE-------
        public void update_simple1()
        {//single record & one field
            string archivo = "111Libro1_UPD_.xlsx";
            DB_Entity.Adjunto.Single(x => x.ID == 1).Archivo = archivo;
            DB_Entity.SaveChanges();
        }

        public void update_simple2()
        {//single record & multiple fields
            string archivo = "111Libro1_UPD2_.xlsx";
            var rec_change = DB_Entity.Adjunto.Single(x => x.ID == 1);
            rec_change.Archivo = archivo;
            rec_change.Ruta = archivo;
            DB_Entity.SaveChanges();
        }

        public void update_multiple1()
        {//multiple records & one field   
            string find = "432432423";
            string replace = "432432423AA";

            DB_Entity.Adjunto.Where(x => x.Archivo == find).ToList().ForEach(x => x.Archivo = replace);
            DB_Entity.SaveChanges();
        }

        public void update_multiple2()
        {//multiple records & multiple fields   
            string find = "432432423AA";
            string replace = "432432423";
            
            DB_Entity.Adjunto.Where(x => x.Archivo == find).ToList().ForEach(x => {
                x.Archivo = replace;
                x.Ruta = replace;
                });
            DB_Entity.SaveChanges();
        }
        //--------------------------------UPDATE-------

        //--------------------------------INSERT-------
        public void insert_simple1()
        {
            ////DATABASE_ENTITY.DATA_TABLE.QUERY
            string newstr = "new test";
            DB_Entity.Adjunto.Add(new Adjunto { Archivo = newstr, Ruta = newstr });
            DB_Entity.SaveChanges();
        }

        public void insert_multiple1()
        {
            List<Adjunto> lsn3 = new List<Adjunto>();
            lsn3.Add(new Adjunto { Archivo = "archivo nuevo", Ruta = "ruta nueva" });
            lsn3.Add(new Adjunto { Archivo = "archivo nuevo2", Ruta = "ruta nueva2" });

            lsn3.ForEach(x => DB_Entity.Adjunto.Add(x));
            //lsn3.ForEach(x =>
            //    {
            //        DB_Entity.Adjunto.Add(x);
            //    });
            DB_Entity.SaveChanges();
        }

        public void insert_multiple2()
        {
            List<dynamic> lsn3 = new List<dynamic>();
            lsn3.Add(new { Archivo = "archivo nuevo", Ruta = "ruta nueva" });
            lsn3.Add(new { Archivo = "archivo nuevo2", Ruta = "ruta nueva2" });

            lsn3.ForEach(x => DB_Entity.Adjunto.Add(new Adjunto { Archivo = x.Archivo, Ruta = x.Ruta }));
            //lsn3.ForEach(x => 
            //    {
            //        DB_Entity.Adjunto.Add(new Adjunto { Archivo = x.Archivo, Ruta = x.Ruta });
            //    });
            DB_Entity.SaveChanges();
        }

        public void insert_return_ID1()
        {
            Adjunto newobj = new Adjunto { Archivo = "new test", Ruta = "new test" };
            DB_Entity.Adjunto.Add(newobj);
            DB_Entity.SaveChanges();
            int Ret_ID = newobj.ID;
        }
        //--------------------------------INSERT-------

        //---VARIADO---VARIADO---VARIADO---VARIADO---VARIADO---VARIADO---VARIADO---VARIADO---VARIADO---VARIADO---
        public void variado1()
        {//realizo un group by, obtengo el count de cada grupo, obtengo de forma detallada y simple los resultados
            var lista = DB_Entity.Adjunto.GroupBy(x => new { x.Archivo, x.Ruta }).ToList();
            var ls2 = lista.Select(x => new { Key = x.Key, son = x.Count() }).ToList();

            var fin3 = lista.Select(x => new Adjunto
            {
                ID = x.Count(),
                Archivo = x.First().Archivo,
                Ruta = x.First().Ruta
            }).OrderByDescending(x => x.ID)
            .ToList();

            var fin31 = lista.Where(x => x.Count() > 1).Select(x => new Adjunto
            {
                ID = x.Count(),
                Archivo = x.First().Archivo,
                Ruta = x.First().Ruta
            }).OrderByDescending(x => x.ID).ToList();
        }

        public void variado2()
        {//en caso de no obtener un resultado con la busqueda, retorno un modelo vacio con
            //DefaultIfEmpty(new MODELO_DE_LA_BUSQUEDA()).ToList();
            var res = DB_Entity.Adjunto.Where(x => x.ID == 9999).ToList().DefaultIfEmpty(new Adjunto()).ToList();
        }
    }
}