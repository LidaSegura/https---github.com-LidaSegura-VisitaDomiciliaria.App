using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VisitaDomiciliaria.App.Dominio;
using VisitaDomiciliaria.App.Persistencia;

namespace VisitaDomiciliaria.App.Presentacion.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioPropietario repositorioPropietarios;
        public Propietario Propietario {set;get;}
        public DetailsModel()
        {
            this.repositorioPropietarios=new RepositorioPropietario(new VisitaDomiciliaria.App.Persistencia.AppContext());
        }
        public IActionResult OnGet(int propietarioid)
        {
            Propietario = repositorioPropietarios.GetPropietario(propietarioid);
            if(Propietario==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
            
        }
    }
}
