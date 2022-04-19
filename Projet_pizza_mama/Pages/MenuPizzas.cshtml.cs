using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projet_pizza_mama.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Projet_pizza_mama.Pages
{
    public class MenuPizzasModel : PageModel
    {
        private readonly Projet_pizza_mama.Data.DataContext _contect;
        private object p;

        public MenuPizzasModel(Projet_pizza_mama.Data.DataContext context)
        {
            _contect = context;
        }
        public IList<Pizza> Pizza { get; set; }

        public async Task OnGetAsync()
        {
            Pizza = await _contect.Pizzas.ToListAsync();
            //range la liste par ordre croissant du plus petit au plus grand
            Pizza = Pizza.OrderBy(p => p.prix).ToList();
        }
    }
}
