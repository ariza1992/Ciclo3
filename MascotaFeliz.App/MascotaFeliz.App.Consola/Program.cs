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
            //ListarMascotasFiltro();
            //EliminarDueno(8);
            //EliminarVeterinario(4);
            //EliminarMascota(2);
            //ActualizarDueno(1);
            //ActualizarVeterinario(5);
            //ActualizarMascota(3);
            //AsignarVeterinario();
            AsignarDueno();

        }

        //------------------------------------AGREGAR----------------------------------

    private static void AddDueno()
        {
            var dueno = new Dueno
            {
                Nombres = "Sofi",
                Apellidos = "A",
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
                Nombres = "Cesar",
                Apellidos = "Millan",
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
        Nombre = "Rex",
        Color = "Verde",
        Especie = "Dino",
        Raza = "Criollo"
        //Dueno = 1
        };
    _repoMascota.AddMascota(mascota);
    }

    //---------------------------------------BUSCAR------------------------------------

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

    //-------------------------------------LISTAR-------------------------------------

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

    //-------------------------------LISTAR POR FILTRO--------------------------------

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

    //-------------------------------------ELIMINAR-----------------------------------

    private static void EliminarDueno (int idDueno)
    {
        _repoDueno.DeleteDueno(idDueno);
        Console.WriteLine ("Se elimino el dueño con Id: " + idDueno);
    }

    private static void EliminarVeterinario (int idVeterinario)
    {
        _repoVeterinario.DeleteVeterinario(idVeterinario);
        Console.WriteLine ("Se elimino el veterinario con Id: " + idVeterinario);
    }

    private static void EliminarMascota (int idMascota)
    {
        _repoMascota.DeleteMascota(idMascota);
        Console.WriteLine ("Se elimino la mascota con Id: " + idMascota);
    }

    //-----------------------------------ACTUALIZAR-----------------------------------

    private static void ActualizarDueno(int idDueno)
        {
            var dueno = new Dueno
            {
                Id = idDueno,
                Nombres = "Sofi",
                Apellidos = "A",
                Direccion = "Carrera",
                Telefono = "310",
                Correo = "sofia@gmail.com"
            };
            _repoDueno.UpdateDueno(dueno);
            Console.WriteLine ("Se actualizo el dueño con Id: " + idDueno);
        }

    private static void ActualizarVeterinario(int idVeterinario)
        {
            var veterinario = new Veterinario
            {
                Id = idVeterinario,
                Nombres = "Cami",
                Apellidos = "A",
                Direccion = "Avenida",
                Telefono = "312",
                TarjetaProfesional = "56789"
            };
            _repoVeterinario.UpdateVeterinario(veterinario);
            Console.WriteLine ("Se actualizo el veterinario con Id: " + idVeterinario);
        }

    private static void ActualizarMascota(int idMascota)
        {
            var mascota = new Mascota 
            {
                Id = idMascota,
                Nombre = "TRex",
                Color = "Azul",
                Especie = "Dinosaurio",
                Raza = "Criollo"
            };
            _repoMascota.UpdateMascota(mascota);
            Console.WriteLine ("Se actualizo la mascota con Id: " + idMascota);
    }

    //--------------------------------ASIGNAR---------------------------------------

    private static void AsignarVeterinario()
    {
        var veterinario = _repoMascota.AsignarVeterinario (1,7);
        Console.WriteLine(veterinario.Nombres + " " + veterinario.Apellidos);
    }

    private static void AsignarDueno()
    {
        var veterinario = _repoMascota.AsignarDueno (1,3);
        Console.WriteLine(veterinario.Nombres + " " + veterinario.Apellidos);
    }

    /*
        private static void AsignarVisitaPyP(int idHistoria)
        {
            var historia = _repoHistoria.GetHistoria(idHistoria);
            if (historia != null)
            {
                if (historia.VisitasPyP != null)
                {
                    historia.VisitasPyP.Add(new VisitaPyP 
                    { 
                        FechaVisita = new DateTime(2020, 01, 01), 
                        Temperatura = 38.0F, Peso = 30.0F, 
                        FrecuenciaRespiratoria = 71.0F, 
                        FrecuenciaCardiaca = 71.0F, 
                        EstadoAnimo = "Muy cansón", 
                        CedulaVeterinario = "123", 
                        Recomendaciones = "Dieta extrema"
                    });
                }
                else
                {
                    historia.VisitasPyP = new List<VisitaPyP>
                    {
                        new VisitaPyP
                        {
                            FechaVisita = new DateTime(2020, 01, 01), 
                            Temperatura = 38.0F, Peso = 30.0F, 
                            FrecuenciaRespiratoria = 71.0F, 
                            FrecuenciaCardiaca = 71.0F, 
                            EstadoAnimo = "Muy cansón", 
                            CedulaVeterinario = "123", 
                            Recomendaciones = "Dieta extrema" 
                            }
                    };
                }
                _repoHistoria.UpdateHistoria(historia);
            }
        }
        */

    

    }
}
