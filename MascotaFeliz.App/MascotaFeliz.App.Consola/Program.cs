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
        private static IRepositorioMascota _repoMascota = new RepositorioMascota (new Persistencia.AppContext());

        static void Main(string[] args)
        {
            //Console.WriteLine("Hola amigos vamos a empezar a trabjar con las tablas");

            //AddDueno();
            //AddVeterinario();
            //AddMascota();
            //BuscarDueno(1);
            //BuscarVeterinario(4);
            //BuscarMascota(1);
            //ListarDuenos();
            //ListarVeterinarios();
            //ListarMascotas();
            //ListarDuenosFiltro();
            //ListarVeterinariosFiltro();
            ListarMascotasFiltro();

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
                Nombres = "Daniel",
                Apellidos = "Renteria",
                Direccion = "Avenida",
                Telefono = "312",
                TarjetaProfesional = "56789"
            };
            _repoVeterinario.AddVeterinario(veterinario);
        }

    private static void AddMascota()
    {
        var mascota = new Mascota 
        {
        Nombre = "Michi",
        Color = "Blanco",
        Especie = "Gato",
        Raza = "Criollo"
        };
    _repoMascota.AddMascota(mascota);
    }

    private static void BuscarDueno (int idDueno)
    {
        var dueno = _repoDueno.GetDueno(idDueno);
        Console.WriteLine (dueno.Nombres + " / " + dueno.Apellidos + " / " + dueno.Direccion + " / " + dueno.Telefono + " / " + dueno.Correo);

    }

    private static void BuscarVeterinario (int idVeterinario)
    {
        var veterinario = _repoVeterinario.GetVeterinario(idVeterinario);
        Console.WriteLine (veterinario.Nombres + " / " + veterinario.Apellidos + " / " + veterinario.Direccion + " / " + veterinario.Telefono + " / " + veterinario.TarjetaProfesional);

    }

    private static void BuscarMascota (int idMascota)
    {
        var mascota = _repoMascota.GetMascota(idMascota);
        Console.WriteLine (mascota.Nombre + " / " + mascota.Color + " / " + mascota.Especie + " / " + mascota.Raza + " / " + mascota.Dueno + " / " + mascota.Veterinario);
    }

    private static void ListarDuenos()
    {
        var duenos = _repoDueno.GetAllDuenos();
        foreach (Dueno d in duenos)
        {
            Console.WriteLine (d.Id + " " + d.Nombres + " " + d.Apellidos);
        }
    }

    private static void ListarVeterinarios()
    {
        var veterinarios = _repoVeterinario.GetAllVeterinarios();
        foreach (Veterinario d in veterinarios)
        {
            Console.WriteLine (d.Id + " " + d.Nombres + " " + d.Apellidos);
        }
    }

    private static void ListarMascotas()
    {
        var mascotas = _repoMascota.GetAllMascotas();
        foreach (Mascota d in mascotas)
        {
            Console.WriteLine (d.Id + " " + d.Nombre + " " + d.Color);
        }
    }

    private static void ListarDuenosFiltro()
    {
        var duenos = _repoDueno.GetDuenosPorFiltro("J");
        foreach (Dueno d in duenos)
        {
            Console.WriteLine (d.Id + " " + d.Nombres + " " + d.Apellidos);
        }
    }

    private static void ListarVeterinariosFiltro()
    {
        var veterinarios = _repoVeterinario.GetVeterinariosPorFiltro("D");
        foreach (Veterinario d in veterinarios)
        {
            Console.WriteLine (d.Id + " " + d.Nombres + " " + d.Apellidos);
        }
    }

    private static void ListarMascotasFiltro()
    {
        var mascotas = _repoMascota.GetMascotasPorFiltro("M");
        foreach (Mascota d in mascotas)
        {
            Console.WriteLine (d.Id + " " + d.Nombre + " " + d.Color);
        }
    }

    }
}
