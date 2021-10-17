using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VisitaDomiciliaria.App.Dominio;
using VisitaDomiciliaria.App.Persistencia;
using Microsoft.AspNetCore.Authorization;

namespace VisitaDomiciliaria.App.Presentacion.Pages
{
    public class ListModel : PageModel
    {
        private readonly IRepositorioPropietario repositorioPropietarios;
        public IEnumerable<Propietario> Propietarios {set;get;}
        public ListModel()
        {
            this.repositorioPropietarios= new RepositorioPropietario(new VisitaDomiciliaria.App.Persistencia.AppContext());
        }
        public void OnGet(string filtroBusqueda)
        {
            Propietarios = repositorioPropietarios.GetAllPropietarios();
        }
    }
}
