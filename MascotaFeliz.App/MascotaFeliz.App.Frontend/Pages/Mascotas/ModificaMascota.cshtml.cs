using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class ModificaMascotaModel : PageModel
    {
        private readonly IRepositorioMascota _repoMascota;
        private readonly IRepositorioDueno _repoDueno;
        private readonly IRepositorioVeterinario _repoVeterinario;
        private readonly IRepositorioHistoria _repoHistoria;
        [BindProperty]
        public Mascota mascota {get;set;}
        public Veterinario veterinario {get;set;}
        public Dueno dueno {get;set;}
        public Historia historia {get;set;}
        public IEnumerable<Dueno> listaDuenos {get;set;}
        public IEnumerable<Veterinario> listaVeterinarios {get;set;}
        public String pageName;
        public DateTime fechaActual = DateTime.Now;

        public ModificaMascotaModel()
        {
            this._repoMascota = new RepositorioMascota(new Persistencia.AppContext());
            this._repoDueno = new RepositorioDueno(new Persistencia.AppContext());
            this._repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
            this._repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());
            pageName = "Agregar una nueva Mascota";
        }

        public void OnGet (int? mascotaId)
        {
            listaDuenos = _repoDueno.GetAllDuenos();
            listaVeterinarios = _repoVeterinario.GetAllVeterinarios();

            if (mascotaId.HasValue)
            {
                mascota = _repoMascota.GetMascota(mascotaId.Value);
                pageName = "Modificar Mascota";
            }
            else
            {
                pageName = "Agregar una nueva Mascota";
                mascota = new Mascota();
            }
            if (mascota ==null)
            {
                RedirectToPage("./NotFound");
            }
            Page();
        }

        public IActionResult OnPost(Mascota mascota, int duenoId, int veterinarioId, Historia historia)
        {
            if (ModelState.IsValid)
            {
                dueno = _repoDueno.GetDueno(duenoId);
                veterinario = _repoVeterinario.GetVeterinario(veterinarioId);
                
                if (mascota.Id>0)
                {
                    mascota.Veterinario = veterinario;
                    mascota.Dueno = dueno;
                    mascota.Historia = historia;
                    mascota = _repoMascota.UpdateMascota(mascota);
                }
                else
                {
                    mascota = _repoMascota.AddMascota(mascota);
                    _repoMascota.AsignarDueno(mascota.Id, dueno.Id);
                    _repoMascota.AsignarVeterinario(mascota.Id, veterinario.Id);
                    _repoHistoria.AddHistoria(historia);
                    _repoMascota.AsignarHistoria(mascota.Id, historia.Id);
                    historia.FechaInicial = fechaActual;
                    _repoHistoria.UpdateHistoria(historia);
            }
            return RedirectToPage("/Mascotas/ListaMascotas");
            }
        else
        {
            return Page();
        }
        }
}
}

