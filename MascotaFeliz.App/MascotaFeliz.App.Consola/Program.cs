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
        private static IRepositorioHistoria _repoHistoria = new RepositorioHistoria (new Persistencia.AppContext());
        private static IRepositorioVisitaPyP _repoVisitaPyP = new RepositorioVisitaPyP (new Persistencia.AppContext());

        static void Main(string[] args)
        {
            //Console.WriteLine("Hola amigos vamos a empezar a trabjar con las tablas");

            //AddDueno();
            //AddVeterinario();
            //AddMascota();
            //AddHistoria();
            //AddVisitaPyP();

            //BuscarDueno(1);
            //BuscarVeterinario(4);
            //BuscarMascota(5);
            //BuscarHistoria (3);
            //BuscarVisitaPyP (1);

            //ListarDuenos();
            //ListarVeterinarios();
            //ListarMascotas();
            //ListarHistorias();
            //ListarVisitasPyP();

            //ListarDuenosFiltro();
            //ListarVeterinariosFiltro();
            //ListarMascotasFiltro();
            ListarVisitasPyPPorFiltro();
            
            //EliminarDueno(8);
            //EliminarVeterinario(4);
            //EliminarMascota(4);
            //EliminarHistoria (2);
            //EliminarVisitaPyP (3);

            //ActualizarDueno(1);
            //ActualizarVeterinario(5);
            //ActualizarMascota(4);
            //ActualizarHistoria(1);
            //ActualizarVisitaPyP(5);

            //AsignarVeterinario();
            //AsignarDueno();
            //AsignarHistoria();
            //AsignarVisitaPyP(5);
            
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

    private static void AddHistoria()
    {
        var historia = new Historia 
        {
        //FechaInicial = DateTime.Today,
        FechaInicial = DateTime.Now,
        };
    _repoHistoria.AddHistoria(historia);
    }

    private static void AddVisitaPyP()
    {
        var visitaPyP = new VisitaPyP 
        {
        FechaVisita = DateTime.Now,
        Temperatura = 38,
        Peso = 50,
        FrecuenciaRespiratoria = 70,
        FrecuenciaCardiaca = 90,
        EstadoAnimo = "Feliz",
        IdVeterinario = 7,
        Recomendaciones = "Ninguna"
        };
    _repoVisitaPyP.AddVisitaPyP(visitaPyP);
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
        Console.WriteLine (mascota.Nombre + " / " + mascota.Color + " / " + mascota.Especie + " / " + mascota.Raza + " / " + mascota.Dueno + " / " + mascota.Veterinario + " / " + mascota.Historia);
    }

    private static void BuscarHistoria (int idHistoria)
    {
        var historia = _repoHistoria.GetHistoria(idHistoria);
        Console.WriteLine (historia.Id + " / " + historia.FechaInicial);
    }

    private static void BuscarVisitaPyP (int idVisitaPyP)
    {
        var visitaPyP = _repoVisitaPyP.GetVisitaPyP(idVisitaPyP);
        Console.WriteLine (visitaPyP.Id + " / " + visitaPyP.FechaVisita);
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

    private static void ListarHistorias()
    {
        var historias = _repoHistoria.GetAllHistorias();
        foreach (Historia d in historias)
        {
            Console.WriteLine (d.Id + " " + d.FechaInicial);
        }
    }

    private static void ListarVisitasPyP()
    {
        var visitasPyP = _repoVisitaPyP.GetAllVisitasPyP();
        foreach (VisitaPyP d in visitasPyP)
        {
            Console.WriteLine (d.Id + " " + d.FechaVisita);
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

    private static void ListarVisitasPyPPorFiltro()
    {
        var visitasPyP = _repoVisitaPyP.GetVisitasPyPPorFiltro(1);
        foreach (VisitaPyP d in visitasPyP)
        {
            Console.WriteLine (d.Id + " " + d.FechaVisita + " " + d.IdVeterinario);
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

    private static void EliminarHistoria (int idHistoria)
    {
        _repoHistoria.DeleteHistoria(idHistoria);
        Console.WriteLine ("Se elimino la historia con Id: " + idHistoria);
    }

    private static void EliminarVisitaPyP (int idVisitaPyP)
    {
        _repoVisitaPyP.DeleteVisitaPyP(idVisitaPyP);
        Console.WriteLine ("Se elimino la historia con Id: " + idVisitaPyP);
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
                Raza = "Criollo",
                /*Dueno = 3,
                Veterinario = 7,
                Historia = 1*/
            };
            _repoMascota.UpdateMascota(mascota);
            Console.WriteLine ("Se actualizo la mascota con Id: " + idMascota);
    }

    private static void ActualizarHistoria(int idHistoria)
        {
            var historia = new Historia 
            {
                Id = idHistoria,
                FechaInicial = DateTime.Now,
            };
            _repoHistoria.UpdateHistoria(historia);
            Console.WriteLine ("Se actualizo la historia con Id: " + idHistoria);
    }

    private static void ActualizarVisitaPyP(int idVisitaPyP)
        {
            var visitaPyP = new VisitaPyP 
            {
            Id = idVisitaPyP,
            FechaVisita = DateTime.Now,
            Temperatura = 39,
            Peso = 51,
            FrecuenciaRespiratoria = 71,
            FrecuenciaCardiaca = 91,
            EstadoAnimo = "Feliz",
            IdVeterinario = 5,
            Recomendaciones = "Ninguna"
            };
            _repoVisitaPyP.UpdateVisitaPyP(visitaPyP);
            Console.WriteLine ("Se actualizo la visitaPyP con Id: " + idVisitaPyP);
    }

    //--------------------------------ASIGNAR---------------------------------------

    private static void AsignarVeterinario()
    {
        var veterinario = _repoMascota.AsignarVeterinario (4,5);
        Console.WriteLine(veterinario.Nombres + " " + veterinario.Apellidos);
    }

    private static void AsignarDueno()
    {
        var dueno = _repoMascota.AsignarDueno (5,9);
        Console.WriteLine(dueno.Nombres + " " + dueno.Apellidos);
    }

    private static void AsignarHistoria()
    {
        var historia = _repoMascota.AsignarHistoria (4,1);
        Console.WriteLine(historia.Id + " " + historia.FechaInicial);
    }

    private static void AsignarVisitaPyP(int idHistoria)
        {
            var historia = _repoHistoria.GetHistoria(idHistoria);
            if (historia != null)
            {
                          
                historia.VisitasPyP = new List<VisitaPyP>
                {
                    new VisitaPyP
                    {
                    FechaVisita = DateTime.Now,
                    Temperatura = 36,
                    Peso = 10,
                    FrecuenciaRespiratoria = 100,
                    FrecuenciaCardiaca = 110,
                    EstadoAnimo = "Distraido",
                    IdVeterinario = 5,
                    Recomendaciones = "Ninguna"
                    }
                };
                }
                _repoHistoria.UpdateHistoria(historia);
            }


    /*
    private static void AsignarVisitaPyP()
    {
        var visitaPyP = _repoMascota.AsignarVisitaPyP (1,4);
        Console.WriteLine(visitaPyP.Id + " " + visitaPyP.FechaVisita);
    }
    */


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
                    FechaVisita = DateTime.Now,
                    Temperatura = 38,
                    Peso = 50,
                    FrecuenciaRespiratoria = 70,
                    FrecuenciaCardiaca = 90,
                    EstadoAnimo = "Feliz",
                    IdVeterinario = 7,
                    Recomendaciones = "Ninguna"
                    });
                }
                else
                {
                historia.VisitasPyP = new List<VisitaPyP>
                {
                    new VisitaPyP
                    {
                    FechaVisita = DateTime.Now,
                    Temperatura = 38,
                    Peso = 50,
                    FrecuenciaRespiratoria = 70,
                    FrecuenciaCardiaca = 90,
                    EstadoAnimo = "Feliz",
                    IdVeterinario = 7,
                    Recomendaciones = "Ninguna"
                    }
                };
                }
                _repoHistoria.UpdateHistoria(historia);
            }
    }
    */


    

    }
}
