using SUS.HTTP;
using SUS.MvcFramework;
using System;

namespace BattleCards.Controllers
{
    public class UsersController : Controller
    {
        // GET /users/register
        public HttpResponse Register()
        {
            return this.View();
        }


        //POST /users/register
        [HttpPost("/Users/Register")]
        public HttpResponse DoRegister()
        {
            //TODO: read data
            //TODO: check if data is valid
            //TODO: register user
            return this.View();
        }

        // GET /users/login
        public HttpResponse Login()
        {
            return this.View();
        }

        //POST /users/login
        [HttpPost("/Users/Login")]
        public HttpResponse DoLogin()
        {
            // TODO: read data
            // TODO: check user
            // TODO: log user
            return this.Redirect("/");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Error("Only logged-in users can logout.");
            }

            this.SignOut();
            return this.Redirect("/");
        }
    }
}
