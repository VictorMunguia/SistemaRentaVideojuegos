using RentaVideojuegosMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentaVideojuegosMVC5.ViewModel;
using System.Data.Entity;
using System.Net;

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
        public ActionResult Index()//Controlador para llenar la vista Index
        {
            var ListaJuegosBase = _context.VideojuegosBaseDatos.Include(c => c.Genero).Include(c => c.Edad).ToList();

            return View(ListaJuegosBase);
        }

        public ActionResult Detalles(int Id)//Controlador para llenar la vista de detalles
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

        public ActionResult Nuevo()//Controlador para llenar la vista del formulario para crear un juego
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
        public ActionResult Crear(Videojuego Videojuego)//Controlador para guardar un nuevo juego desde la vista nuevo
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

        public ActionResult Modificar(int Id)//Controlador para llenar la vista modificar.
        {
            var Juego = _context.VideojuegosBaseDatos.SingleOrDefault(c => c.Id == Id);

            if(Juego == null)
            {
                return HttpNotFound();
            }
            else
            {
                var ViewModelVideojuego = new VideojuegosViewModel
                {
                    Videojuego = Juego,
                    ListaGenero = _context.GenerosBaseDatos.ToList(),
                    ListaEdad = _context.EdadesBaseDatos.ToList()
                };

                return View(ViewModelVideojuego);
            }
           
            
        }

        public ActionResult ModificarInformacion(Videojuego Videojuego)
        {
            if (!ModelState.IsValid)
            {
                var ViewModel = new VideojuegosViewModel
                {
                    Videojuego = Videojuego,
                    ListaGenero = _context.GenerosBaseDatos.ToList(),
                    ListaEdad = _context.EdadesBaseDatos.ToList()
                    

                };

                return View("Modificar", ViewModel);// Esta condicion compara si es valido todo esto, en caso de que sea diferente de valido returnaremos al usuario al formulario con todo lo que a llenado pero imprimiremos los mensajes de error.
            }
           
            
                var VideojuegoBaseDeDatos = _context.VideojuegosBaseDatos.Single(c => c.Id == Videojuego.Id);

                VideojuegoBaseDeDatos.Nombre = Videojuego.Nombre;
                VideojuegoBaseDeDatos.Descripcion = Videojuego.Descripcion;
                VideojuegoBaseDeDatos.FechaDePublicacion = Videojuego.FechaDePublicacion;
                VideojuegoBaseDeDatos.NumeroDisponiblre = Videojuego.NumeroDisponiblre;
                VideojuegoBaseDeDatos.EdadId = Videojuego.EdadId;
                VideojuegoBaseDeDatos.GeneroId = Videojuego.GeneroId;

                _context.SaveChanges();

                return RedirectToAction(Convert.ToString(Detalles(VideojuegoBaseDeDatos.Id)), "Videojuegos");
            
        }
    }
}