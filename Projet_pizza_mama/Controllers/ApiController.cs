using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Projet_pizza_mama.Data;
using Projet_pizza_mama.Models;
using System.Linq;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projet_pizza_mama.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : Controller
    {

        DataContext dataContect;
        //on appelle le DataContect pour utiliser utiliser le model Pizzas et les données qui sont dans notre basse de données
        public ApiController(DataContext dataContect)
        {
            this.dataContect = dataContect;
        }
        //Retourne tout les données des pizzas donnée en format Json
        [HttpGet]
        [Route("GetPizzas")]
        public IActionResult GetPizzas()
        {
            //var pizza = new Pizza() { nom= "pizza_test", vegetarienne=false, prix=20, ingredients="tomate, oeuf, fromage"};
            var pizza = dataContect.Pizzas.ToList();//Recupere la liste des pizza qui sont dans la base de données
            
            return Json(pizza);//transforme les données en format json
        }

    }
}
