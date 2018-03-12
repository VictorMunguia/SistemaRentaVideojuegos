using RentaVideojuegosMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentaVideojuegosMVC5.Models;
using RentaVideojuegosMVC5.ViewModel;
using System.Data.Entity;

namespace RentaVideojuegosMVC5.Controllers
{
    public class VideojuegosController : Controller
    {
        private ApplicationDbContext _context;

        public VideojuegosController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Videojuegos
        public ActionResult Index()
        {
            var ListaJuegosBase = _context.VideojuegosBaseDatos.Include(c => c.Genero).Include(c => c.Edad).ToList();

            return View(ListaJuegosBase);
        }

        public ActionResult Detalles(int Id)
        {
            var Juego = _context.VideojuegosBaseDatos.Include(c => c.Genero).Include(c => c.Edad).SingleOrDefault(c => c.Id == Id);
            if (Juego == null)
            {
                return HttpNotFound();
            }
            else
            {
               return View(Juego);
            }
            
        }

        public ActionResult Nuevo()
        {
            var GenerosLista = _context.GenerosBaseDatos.ToList();
            var EdadesLista = _context.EdadesBaseDatos.ToList();

            var ViewModelDatosListas = new VideojuegosViewModel
            {
                Videojuego = new Videojuego(),
                ListaGenero = GenerosLista,
                ListaEdad = EdadesLista
            };

            return View(ViewModelDatosListas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrUpdate(Videojuego Videojuego)
        {
            if(!ModelState.IsValid)
            {
                var ViewModel = new VideojuegosViewModel
                {
                    Videojuego = Videojuego,
                    ListaGenero = _context.GenerosBaseDatos.ToList(),
                    ListaEdad = _context.EdadesBaseDatos.ToList()
                };

                return View("Nuevo", ViewModel);
            }
            else
            {
                _context.VideojuegosBaseDatos.Add(Videojuego);
                _context.SaveChanges();

                return RedirectToAction("Index", "Videojuegos");
            }
        }
    }
}