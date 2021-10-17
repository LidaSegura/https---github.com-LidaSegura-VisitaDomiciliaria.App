using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VisitaDomiciliaria.App.Dominio;
using VisitaDomiciliaria.App.Persistencia;

namespace VisitaDomiciliaria.App.Presentacion.Pages
{   public class DeleteModel : PageModel
    {
        private readonly IRepositorioPropietario repositorioPropietarios;
        [BindProperty]
        public Propietario Propietario {set;get;}
        public DeleteModel()
        {
            this.repositorioPropietarios=new RepositorioPropietario(new VisitaDomiciliaria.App.Persistencia.AppContext());
        } 
        public IActionResult OnGet(int? propietarioId)
        {
            if (propietarioId.HasValue)
            {
                Propietario = repositorioPropietarios.GetPropietario(propietarioId.Value);
            }
            if (Propietario == null)
            {
                return RedirectToPage("./Notfound");
            }
            else
            {
                return Page();
            }
        }    
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Propietario.Id>0)
            {
                repositorioPropietarios.DeletePropietario(Propietario.Id);
            }
            else
            {
                repositorioPropietarios.AddPropietario(Propietario);
            }
            return Page();
        }
    }
}
