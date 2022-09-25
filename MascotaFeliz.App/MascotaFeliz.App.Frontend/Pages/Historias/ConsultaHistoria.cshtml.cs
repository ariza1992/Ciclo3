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
        public Historia historia {get;set;}
        public ConsultaHistoriaModel()
        {
            this._repoHistoria = new RepositorioHistoria (new Persistencia.AppContext());
        }

        public IActionResult OnGet(int historiaId)
        {
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
