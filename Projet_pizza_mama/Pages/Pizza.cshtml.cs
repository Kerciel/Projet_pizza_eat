using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projet_pizza_mama.Models;
using System.Threading.Tasks;

namespace Projet_pizza_mama.Pages
{
    
    public class PizzaModel : PageModel
    {
        private readonly Projet_pizza_mama.Data.DataContext _context;
        public PizzaModel(Projet_pizza_mama.Data.DataContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Pizza Pizza { get; set; }

        //Recuperation de la pizza avec id de la pizza avec la methode GET
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pizza = await _context.Pizzas.FirstOrDefaultAsync(m => m.PizzaID == id);

            if (Pizza == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
