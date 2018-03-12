using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentaVideojuegosMVC5.Models;
using System.ComponentModel.DataAnnotations;

namespace RentaVideojuegosMVC5.Models
{
    public class Videojuego
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Nombre del Videojuego")]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Range(1, 20)]
        [Display(Name = "Numero de juegos disponible")]
        public int NumeroDisponiblre { get; set; }

        public DateTime? FechaDePublicacion { get; set; }

        public Genero Genero { get; set; }

        [Required]
        [Display(Name = "Genero")]
        public int GeneroId { get; set; }

        public Edad Edad { get; set; }

        [Required]
        [Display(Name = "Edad Recomendada")]
        public int EdadId { get; set; }
    }
}