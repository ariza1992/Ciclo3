using System;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using System.Collections.Generic;

namespace MascotaFeliz.App.Consola
{
    class Program
    {

        private static IRepositorioDueno _repoDueno = new RepositorioDueno(new Persistencia.AppContext());



        static void Main(string[] args)
        {
            Console.WriteLine("Hola amigos vamos a empezar a trabjar con las tablas");


            AddDueno();



        }

        private static void AddDueno()
        {
            var dueno = new Dueno
            {
                //Cedula = "1212",
                Nombres = "Sebastian",
                Apellidos = "Ariza",
                Direccion = "Calle",
                Telefono = "300",
                Correo = "sebastian@gmail.com"
            };
            _repoDueno.AddDueno(dueno);
        }



    }
}
