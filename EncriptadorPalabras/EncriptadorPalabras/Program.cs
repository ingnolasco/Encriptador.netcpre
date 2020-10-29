using EncriptadorPalabras.Clases;
using System;

namespace EncriptadorPalabras
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Encriptador encriptador = new Encriptador();

            var resul = encriptador.Cifrar("CRECER_NOTIFICACION_SEPP");

            Console.WriteLine(resul);

            var palabra = encriptador.Descifrar(resul);
            Console.WriteLine(palabra);


        }
    }
}
