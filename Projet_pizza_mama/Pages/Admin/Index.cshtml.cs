using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Projet_pizza_mama.Pages.Admin
{
    public class IndexModel : PageModel
    {
        //lorsque on c'est authentier on nous renvoie dans l'index de pizzas 
        public IActionResult OnGet()
        {
            //renvoie la page pizza si on est connecter 
            if(HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/Admin/Pizzas" );
            }
            return Page();
        }
        //permet de verifier les coordonnées rentées pour ce connecter ou non 
        public async Task<IActionResult> OnPostAsync(string username, string passward, string ReturnUrl)
        {

            if (username == "admin")
            {
                var claims = new List<Claim>
                     {
                     new Claim(ClaimTypes.Name, username)
                     };
                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new
               ClaimsPrincipal(claimsIdentity));
                return Redirect(ReturnUrl == null ? "/Admin/Pizzas" : ReturnUrl);
            }
           

                return Page();
            
        }

        public async Task<IActionResult> OnGetLogout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Admin");
        }
    }
}
