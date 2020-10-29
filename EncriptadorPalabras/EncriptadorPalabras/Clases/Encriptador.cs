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
            byte[] llave; //Arreglo donde guardaremos la llave para el cifrado 3DES.
            byte[] arreglo = UTF8Encoding.UTF8.GetBytes(cadena); //Arreglo donde guardaremos la cadena descifrada.
                                                                 // Ciframos utilizando el Algoritmo MD5.

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            llave = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes("CRECER@NOTIFICACIONES_NSP19"));
            md5.Clear();
            //Ciframos utilizando el Algoritmo 3DES.
            TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider
            {
                Key = llave,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform convertir = tripledes.CreateEncryptor(); // Iniciamos la conversión de la cadena
            byte[] resultado = convertir.TransformFinalBlock(arreglo, 0, arreglo.Length); //Arreglo de bytes donde guardaremos la cadena cifrada.
            tripledes.Clear();
            return Convert.ToBase64String(resultado, 0, resultado.Length); // Convertimos la cadena y la regresamos.
        }


        // Función para descifrar una cadena.
        public string Descifrar(string cadena)
        {
            try {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] llave = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes("CRECER@NOTIFICACIONES_NSP19"));//Ciframos utilizando el Algoritmo 3DES.
                byte[] arreglo = Convert.FromBase64String(cadena); // Arreglo donde guardaremos la cadena descovertida.
                md5.Clear();
                TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider
                {
                    Key = llave,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };

                ICryptoTransform convertir = tripledes.CreateDecryptor();
                byte[] resultado = convertir.TransformFinalBlock(arreglo, 0, arreglo.Length);
                tripledes.Clear();
                string cadena_descifrada = UTF8Encoding.UTF8.GetString(resultado); // Obtenemos la cadena
                return cadena_descifrada; // Devolvemos la cadena
            }
            catch (Exception ex) {
                return null;
            }
        }

    }
}
