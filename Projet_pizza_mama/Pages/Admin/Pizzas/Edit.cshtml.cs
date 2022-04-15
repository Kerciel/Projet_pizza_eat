using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projet_pizza_mama.Data;
using Projet_pizza_mama.Models;

namespace Projet_pizza_mama.Pages.Admin.Pizzas
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly Projet_pizza_mama.Data.DataContext _context;

        public EditModel(Projet_pizza_mama.Data.DataContext context)
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

        //partie pour modifier la pizza
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //modifiction de la pizza
           // _context.Attach(Pizza).State = EntityState.Modified;
           _context.Update(Pizza);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaExists(Pizza.PizzaID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PizzaExists(int id)
        {
            return _context.Pizzas.Any(e => e.PizzaID == id);
        }
    }
}
