using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Bst_Test_1.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bst_Test_1.Clases
{
    public class token
    {
        public void master()
        {
            string re2 = "oKnQA6YI7q3HyqeAYuOAI1K+Q3jwN+zGm77nGvRnTpqJGrA6Hn3FxT0nnHUzLuuuQu3EL9vhVb+y6Perm6CNIWxjdbnAt4tV7+51FfR7Klk=";
            string sens = "oKnQA6YI7q3HyqeAYuOAI1K%2BQ3jwN%2BzGm77nGvRnTpqJGrA6Hn3FxT0nnHUzLuuuQu3EL9vhVb%2By6Perm6CNIWxjdbnAt4tV7%2B51FfR7Klk%3D";
             
                         
            
            string rev2 = Desencriptar(re2);
            json2();
        }

        public void check(string res)
        {
            var original = "oKnQA6YI7q3HyqeAYuOAI1K+Q3jwN+zGm77nGvRnTpqJGrA6Hn3FxT0nnHUzLuuuQu3EL9vhVb+y6Perm6CNIWxjdbnAt4tV7+51FfR7Klk=";
            var asd = res.Equals(original);
            var receive = Desencriptar(res);
        }

        public static string Encriptar(string texto)
        {
            try
            {

                string key = "qualityinfosolutions"; //llave para encriptar datos

                byte[] keyArray;

                byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(texto);

                //Se utilizan las clases de encriptación MD5

                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

                hashmd5.Clear();

                //Algoritmo TripleDES
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateEncryptor();

                byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);

                tdes.Clear();

                //se regresa el resultado en forma de una cadena
                texto = Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);

            }
            catch (Exception)
            {

            }
            return texto;
        }

        public static string Desencriptar(string textoEncriptado)
        {
            try
            {
                string key = "qualityinfosolutions";
                byte[] keyArray;
                byte[] Array_a_Descifrar = Convert.FromBase64String(textoEncriptado);

                //algoritmo MD5
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

                hashmd5.Clear();

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();

                byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);

                tdes.Clear();
                textoEncriptado = UTF8Encoding.UTF8.GetString(resultArray);

            }
            catch (Exception)
            {

            }
            return textoEncriptado;
        }

        public void jsontest()
        {
            Adjunto product = new Adjunto();
            //Product product = new Product();

            product.ID = 999;
            product.Archivo = "Archivo";
            product.Ruta = "Ruta";

            string output = JsonConvert.SerializeObject(product);

            var a = Encriptar(output);
            var b = Desencriptar(a);

            Adjunto deserializedProduct = JsonConvert.DeserializeObject<Adjunto>(output);
        }


        //genero una estructura JSON a partir de unas clases
        public void json2()
        {
            string a = "{ 'Cont': 'Test', 'Meth': 'methodtest', 'par':{ 'clie': 'cliente234', 'otro': 'otro_fdd' } }";
            var a1 = JObject.Parse(a);
                       
            var b = new jsonmeth { cont = "controller", meth = "method", clas = new par { clien = "cliente", otro = "otro" } };
            var b1 = JObject.FromObject(b);

            
            var ser = JsonConvert.SerializeObject(b1);
            var enc = Encriptar(ser);
            var des = Desencriptar(enc);
            var for_url = System.Web.HttpUtility.UrlEncode(enc);

            var enc2 = Encriptar(b1.ToString());
            var des2 = Desencriptar(enc2);
            
            jsonmeth js = JsonConvert.DeserializeObject<jsonmeth>(des);
            jsonmeth js2 = JsonConvert.DeserializeObject<jsonmeth>(des2);
        }

        class jsonmeth
        {
            public string cont { get; set; }
            public string meth { get; set; }
            public object clas { get; set; }
        }

        class par 
        {
            public string clien { get; set; }
            public string otro { get; set; }
        }
    }
}