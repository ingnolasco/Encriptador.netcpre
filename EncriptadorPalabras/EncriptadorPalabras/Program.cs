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

            var palabra = encriptador.Descifrar("LAbIbg+mf7zLz9itkdVDmj7z40o87vXJ+w5ugSfsuX4");
            Console.WriteLine(palabra);


        }
    }
}
