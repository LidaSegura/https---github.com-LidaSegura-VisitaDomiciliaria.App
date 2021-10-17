using System;
using VisitaDomiciliaria.App.Dominio;
using VisitaDomiciliaria.App.Persistencia;

namespace VisitaDomiciliaria.App.Consola
{
    class Program
    {
        private static IRepositorioPropietario _repoPropietario = new RepositorioPropietario(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //AddPropietario();
            BuscarPropietario(1);
        }
        private static void AddPropietario()
        {
            var propietario = new Propietario()
            {
                idPersona = "12345",
                Nombres = "Homero J.",
                Apellidos = "Simpson",
                Telefono = "5555",
                Direccion = "Avenida siembre viva 123",
                Correo = "homerosimpson@fox.com"
            };
            _repoPropietario.AddPropietario(propietario);
        }    
        private static void BuscarPropietario(int idPropietario)
        {
            var propietario = _repoPropietario.GetPropietario(idPropietario);
            Console.WriteLine(propietario.Nombres);
        }
    }
}
