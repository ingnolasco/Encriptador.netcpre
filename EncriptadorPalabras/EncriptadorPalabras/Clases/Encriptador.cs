using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace EncriptadorPalabras.Clases
{
   public class Encriptador
    {

        // Función para cifrar una cadena.
        public string Cifrar(string cadena)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            //Arreglo donde guardaremos la llave para el cifrado 3DES.
            byte[] llave= md5.ComputeHash(UTF8Encoding.UTF8.GetBytes("CRECER@NOTIFICACIONES_NSP19")); 
            byte[] arreglo = UTF8Encoding.UTF8.GetBytes(cadena); //Arreglo donde guardaremos la cadena descifrada.
            md5.Clear();
            //Ciframos utilizando el Algoritmo 3DES.
            TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider
            {
                Key = llave,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform convertir = tripledes.CreateEncryptor(); // Iniciamos la conversión de la cadena
            var result = Convert.ToBase64String(convertir.TransformFinalBlock(arreglo, 0, arreglo.Length));
            //Arreglo de bytes donde guardaremos la cadena cifrada.
            tripledes.Clear();
            return result;
        }


        // Función para descifrar una cadena.
        public string Descifrar(string cadena)
        {
            try {
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider()) {
                    byte[] arreglo = Convert.FromBase64String(cadena); // Arreglo donde guardaremos la cadena descovertida.
                    TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider
                    {
                        Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes("CRECER@NOTIFICACIONES_NSP19")),
                        Mode = CipherMode.ECB,
                        Padding = PaddingMode.PKCS7
                    };
                    md5.Clear();
                    ICryptoTransform convertir = tripledes.CreateDecryptor();
                    var result = UTF8Encoding.UTF8.GetString(convertir.TransformFinalBlock(arreglo, 0, arreglo.Length));
                    tripledes.Clear();
                    return result; // Devolvemos la cadena
                }    
            }
            catch (Exception ex) {
                return null;
            }
        }

    }
}
