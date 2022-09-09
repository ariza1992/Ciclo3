using System;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using System.Collections.Generic;

namespace MascotaFeliz.App.Consola
{
    class Program
    {

        private static IRepositorioDueno _repoDueno = new RepositorioDueno(new Persistencia.AppContext());
        private static IRepositorioVeterinario _repoVeterinario = new RepositorioVeterinario (new Persistencia.AppContext());

        static void Main(string[] args)
        {
            Console.WriteLine("Hola amigos vamos a empezar a trabjar con las tablas");

            //AddDueno();
            AddVeterinario();

        }

        private static void AddDueno()
        {
            var dueno = new Dueno
            {
                //Cedula = "1212",
                Nombres = "Erick",
                Apellidos = "ladino",
                Direccion = "Carrera",
                Telefono = "310",
                Correo = "erick@gmail.com"
            };
            _repoDueno.AddDueno(dueno);
        }

    private static void AddVeterinario()
        {
            var veterinario = new Veterinario
            {
                //Cedula = "1212",
                Nombres = "Erick",
                Apellidos = "ladino",
                Direccion = "Carrera",
                Telefono = "310",
                TarjetaProfesional = "12345"
            };
            _repoVeterinario.AddVeterinario(veterinario);
        }

    }
}
