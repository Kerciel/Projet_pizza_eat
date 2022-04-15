using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projet_pizza_mama.Models
{
    public class Pizza
    {
        public int PizzaID { get; set; }

        [Display(Name = ("Nom"))]
        public string nom { get; set; }

        [Display(Name = ("Prix(€)"))]
        public float prix { get; set; }

        [Display(Name = ("Végétarienne"))]

        public bool vegetarienne { get; set; }

        [Display (Name = "Ingrédients")]
        public string ingredients { get; set; }
    }
}
