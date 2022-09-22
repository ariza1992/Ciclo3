using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioMascota : IRepositorioMascota
    {
        /// <summary>
        /// Referencia al contexto de Dueno
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        
        public RepositorioMascota(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Mascota AddMascota(Mascota mascota)
        {
            var mascotaAdicionada = _appContext.Mascotas.Add(mascota);
            _appContext.SaveChanges();
            return mascotaAdicionada.Entity;
        }

        public void DeleteMascota(int idMascota)
        {
            var mascotaEncontrada = _appContext.Mascotas.FirstOrDefault(d => d.Id == idMascota);
            if (mascotaEncontrada == null)
                return;
            _appContext.Mascotas.Remove(mascotaEncontrada);
            _appContext.SaveChanges();
        }

       public IEnumerable<Mascota> GetAllMascotas()
        {
            return GetAllMascotas_();
        }

        public IEnumerable<Mascota> GetMascotasPorFiltro(string filtro)
        {
            var mascotas = GetAllMascotas(); // Obtiene todos los saludos
            if (mascotas != null)  //Si se tienen saludos
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    mascotas = mascotas.Where(s => s.Nombre.Contains(filtro));
                }
            }
            return mascotas;
        }

        public IEnumerable<Mascota> GetAllMascotas_()
        {
            return _appContext.Mascotas.Include("Dueno").Include("Veterinario").Include("Historia");
        }

        public Mascota GetMascota(int idMascota)
        {
            //return _appContext.Mascotas.Include("Dueno").Include("Veterinario").Include("Historia").FirstOrDefault(d => d.Id == idMascota);
            return _appContext.Mascotas.Include(a => a.Dueno).Include(a => a.Veterinario).Include(a => a.Historia).FirstOrDefault(d => d.Id == idMascota);
        }

        public Mascota UpdateMascota(Mascota mascota)
        {
            var mascotaEncontrada = _appContext.Mascotas.FirstOrDefault(d => d.Id == mascota.Id);
            if (mascotaEncontrada != null)
            {
                mascotaEncontrada.Nombre = mascota.Nombre;
                mascotaEncontrada.Color = mascota.Color;
                mascotaEncontrada.Especie = mascota.Especie;
                mascotaEncontrada.Raza = mascota.Raza;
                mascotaEncontrada.Dueno = mascota.Dueno;
                mascotaEncontrada.Veterinario = mascota.Veterinario;
                mascotaEncontrada.Historia = mascota.Historia;
                _appContext.SaveChanges();
            }
            return mascotaEncontrada;
        }

        public Veterinario AsignarVeterinario (int idMascota, int idVeterinario)
        {
            var mascotaEncontrado = _appContext.Mascotas.FirstOrDefault(m=> m.Id == idMascota);
            if (mascotaEncontrado != null)
            {
                var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(v=> v.Id == idVeterinario);
                if (veterinarioEncontrado !=null)
                {
                    mascotaEncontrado.Veterinario = veterinarioEncontrado;
                    _appContext.SaveChanges();
                }
                return veterinarioEncontrado;
            }
            return null;
        }

        public Dueno AsignarDueno (int idMascota, int idDueno)
        {
            var mascotaEncontrado = _appContext.Mascotas.FirstOrDefault(m=> m.Id == idMascota);
            if (mascotaEncontrado != null)
            {
                var duenoEncontrado = _appContext.Duenos.FirstOrDefault(v=> v.Id == idDueno);
                if (duenoEncontrado !=null)
                {
                    mascotaEncontrado.Dueno = duenoEncontrado;
                    _appContext.SaveChanges();
                }
                return duenoEncontrado;
            }
            return null;
        }

        
        public Historia AsignarHistoria (int idMascota, int idHistoria)
        {
            var mascotaEncontrado = _appContext.Mascotas.FirstOrDefault(m=> m.Id == idMascota);
            if (mascotaEncontrado != null)
            {
                var historiaEncontrado = _appContext.Historias.FirstOrDefault(v=> v.Id == idHistoria);
                if (historiaEncontrado !=null)
                {
                    mascotaEncontrado.Historia = historiaEncontrado;
                    _appContext.SaveChanges();
                }
                return historiaEncontrado;
            }
            return null;
        }
        


        /*
        public VisitaPyP AsignarVisitaPyP (int idHistoria)
        {
            var mascotaEncontrado = _appContext.Mascotas.FirstOrDefault(m=> m.Id == idMascota);
            if (mascotaEncontrado != null)
            {
                var historiaEncontrado = _appContext.Historias.FirstOrDefault(v=> v.Id == idHistoria);
                if (historiaEncontrado !=null)
                {
                    mascotaEncontrado.Historia = historiaEncontrado;
                    _appContext.SaveChanges();
                }
                return historiaEncontrado;
            }
            return null;
        }
        */

    }
}
