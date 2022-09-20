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
        [BindProperty]
        public Mascota mascota {get;set;}
        public String pageName;

        public ModificaMascotaModel()
        {
            this._repoMascota = new RepositorioMascota(new Persistencia.AppContext());
            pageName = "Agregar una nueva Mascota";
        }

        public IActionResult OnGet(int? mascotaId)
        {
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
                return RedirectToPage("./NotFound");
            }
            else
                return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (mascota.Id>0)
            {
                mascota = _repoMascota.UpdateMascota(mascota);
            }
            else
            {
                _repoMascota.AddMascota(mascota);
            }
            return Page();
        }
    }
}

