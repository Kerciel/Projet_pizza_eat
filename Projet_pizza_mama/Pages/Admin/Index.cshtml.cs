using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Projet_pizza_mama.Pages.Admin
{
    
    public class IndexModel : PageModel
    {
        public bool erreur = false;
        public bool isdevelopement = false;
        IConfiguration configuration;
        //recuperéation des information de connexion de l'administateur 
        public IndexModel(IConfiguration configuration, IWebHostEnvironment env)
        {
            this.configuration = configuration;
            if (env.IsDevelopment())
            {
                isdevelopement = true;
            }
            else
            {
                isdevelopement = false;
            }
        }
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
        public async Task<IActionResult> OnPostAsync(string username, string password, string ReturnUrl)
        {
            var authsection = configuration.GetSection("Auth");
            string adminloging = authsection["AdmiLogin"];
            string adminPassword = authsection["AdminPassword"];

            if ((username == adminloging)&& (password == adminPassword))
            {
                var claims = new List<Claim>
                     {
                     new Claim(ClaimTypes.Name, username)
                     };
                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new
               ClaimsPrincipal(claimsIdentity));
                this.erreur = false;
                return Redirect(ReturnUrl == null ? "/Admin/Pizzas" : ReturnUrl);

            }
           
            this.erreur = true;
                return Page();

            
        }

        public async Task<IActionResult> OnGetLogout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Admin");
        }
    }
}
