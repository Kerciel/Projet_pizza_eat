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
        public void OnGet()
        {
            Console.WriteLine();
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
    }
}
