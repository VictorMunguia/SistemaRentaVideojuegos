using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentaVideojuegosMVC5.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Nombre del cliente")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Apellido del cliente")]
        public string Apellido { get; set; }

        [Required]
        [Range(1,100)]
        [Display(Name = "Edad del cliente")]
        public int Edad { get; set; }

        [Required]
        [Display(Name ="El cliente tiene suscripcion ? ")]
        public bool EstaSuscrito  { get; set; }

        public GeneroCliente GeneroCliente { get; set; }

        [Required]
        [Display(Name = "Elige genero del cliente")]
        public int GeneroClienteId { get; set; }

        public Membresia Membresia { get; set; }

        [Required]
        [Display(Name ="Elige El tipo de Membresia")]
        public int MembresiaId { get; set; }
    }
}