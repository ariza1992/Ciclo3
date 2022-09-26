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
    public class ConsultaHistoriaModel : PageModel
    {
        private readonly IRepositorioHistoria _repoHistoria;
        private readonly IRepositorioVisitaPyP _repoVisitaPyP;
        private readonly IRepositorioVeterinario _repoVeterinario;
        [BindProperty]
        public Historia historia {get;set;}
        public VisitaPyP visitaPyP {get;set;}
        public IEnumerable<VisitaPyP> listasVisitasPyP {get;set;}

        public ConsultaHistoriaModel()
        {
            this._repoHistoria = new RepositorioHistoria (new Persistencia.AppContext());
            this._repoVisitaPyP = new RepositorioVisitaPyP (new Persistencia.AppContext());
            this._repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        }

        public IActionResult OnGet(int historiaId)
        {
            listasVisitasPyP = _repoVisitaPyP.GetVisitasPyPPorFiltro(historiaId);
            historia = _repoHistoria.GetHistoria(historiaId);
            
            if (historia == null)
            {
                return RedirectToPage ("./NotFound");
            }
            else 
            {
                return Page();
            }

        }
    }
}
