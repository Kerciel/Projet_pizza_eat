using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projet_pizza_mama.Models
{
    public class Pizza
    {
        [JsonIgnore]//permet d'ignorer le champ PizzaId quand on transforme les données en json
        public int PizzaID { get; set; }

        [Display(Name = ("Nom"))]
        public string nom { get; set; }

        [Display(Name = ("Prix(€)"))]
        public float prix { get; set; }

        [Display(Name = ("Végétarienne"))]

        public bool vegetarienne { get; set; }
        [Display (Name = "Ingrédients")]
        [JsonIgnore]
        public string ingredients { get; set; }

        [NotMapped]//ignorer apres sa et ne la stoque pas dans la basse de données
        [JsonPropertyName("ingredients")]//change le nom de ingredients par le tableau de pizza

        public string[] ingredientsList
        {
            get
            {
                if ((ingredients == null) || (ingredients.Count() == 0))
                {
                    return null;
                }
                return ingredients.Split(",");
            }
        }
    }
}
