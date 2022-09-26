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
    public class ModificaVisitaModel : PageModel
    {
        private readonly IRepositorioVisitaPyP _repoVisitaPyP;
        private readonly IRepositorioMascota _repoMascota;
        private readonly IRepositorioVeterinario _repoVeterinario;
        private readonly IRepositorioHistoria _repoHistoria;
        [BindProperty]
        public VisitaPyP visitaPyP {get;set;}
        public Mascota mascota {get;set;}
        public Veterinario veterinario {get;set;}
        public Historia historia {get;set;}
        public IEnumerable<Veterinario> listaVeterinarios {get;set;}
        public IEnumerable<Historia> listaHistorias {get;set;}
        public String pageName;
        public DateTime fechaActual = DateTime.Now;

        public ModificaVisitaModel ()
        {
            this._repoVisitaPyP = new RepositorioVisitaPyP(new Persistencia.AppContext());
            this._repoMascota = new RepositorioMascota(new Persistencia.AppContext());
            this._repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
            this._repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());
            pageName = "Agregar una nueva Mascota";
        }

        public void OnGet (int? visitaId)
        {
            listaHistorias = _repoHistoria.GetAllHistorias();
            listaVeterinarios = _repoVeterinario.GetAllVeterinarios();

            if (visitaId.HasValue)
            {
                visitaPyP = _repoVisitaPyP.GetVisitaPyP(visitaId.Value);
                pageName = "Modificar Visita Medica";
            }
            else
            {
                pageName = "Agregar una nueva Visita Medica";
                visitaPyP = new VisitaPyP();
            }
            if (visitaPyP ==null)
            {
                RedirectToPage("./NotFound");
            }
            Page();
        }

        public IActionResult OnPost(VisitaPyP visitaPyP,int mascotaId, int veterinarioId, int historiaId)
        {
            if (ModelState.IsValid)
            {
                historia = _repoHistoria.GetHistoria(historiaId);
                veterinario = _repoVeterinario.GetVeterinario(veterinarioId);
                
                if (visitaPyP.Id>0)
                {
                    visitaPyP.IdVeterinario = veterinario.Id;
                    visitaPyP.HistoriaId = historia.Id;
                    visitaPyP = _repoVisitaPyP.UpdateVisitaPyP(visitaPyP);
                }
                
                else
                {
                    visitaPyP = _repoVisitaPyP.AddVisitaPyP(visitaPyP);
                    
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
