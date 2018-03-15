using RentaVideojuegosMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentaVideojuegosMVC5.ViewModel;
using System.Data.Entity;

namespace RentaVideojuegosMVC5.Controllers
{
    public class ClientesController : Controller
    {
        private ApplicationDbContext _context;

        public ClientesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Clientes
        public ActionResult Index()
        {
            var Clientes = _context.ClienteBaseDatos.Include(c => c.Membresia).Include(c => c.GeneroCliente).ToList();

            return View(Clientes);
        }
    }
}