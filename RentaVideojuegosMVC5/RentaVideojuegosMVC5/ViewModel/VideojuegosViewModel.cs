using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentaVideojuegosMVC5.Models;

namespace RentaVideojuegosMVC5.ViewModel
{
    public class VideojuegosViewModel
    {
        public IEnumerable<Genero> ListaGenero { get; set; }
        public IEnumerable<Edad> ListaEdad { get; set; }
        public Videojuego Videojuego { get; set; }
    }
}