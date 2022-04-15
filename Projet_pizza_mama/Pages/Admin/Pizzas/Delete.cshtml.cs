using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projet_pizza_mama.Data;
using Projet_pizza_mama.Models;

namespace Projet_pizza_mama.Pages.Admin.Pizzas
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly Projet_pizza_mama.Data.DataContext _context;

        public DeleteModel(Projet_pizza_mama.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pizza Pizza { get; set; }

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pizza = await _context.Pizzas.FindAsync(id);

            if (Pizza != null)
            {
                //supprime le champ trouver dans la basse de donnée
                _context.Pizzas.Remove(Pizza);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
