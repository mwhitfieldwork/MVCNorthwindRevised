using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using NWCodeFirstMVC.App.Contracts;
using NWCodeFirstMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWCodeFirstMVC.Infrastructure.Services
{
    public class LoginService : GenericService<User>, ILoginService
    {
        private readonly northwindContext _dc;
        public LoginService(northwindContext dc) : base(dc)
        {
            this._dc = dc;
        }
        [HttpPost]
        public async Task<IActionResult> Authenticate(User userModel)
        {
            if (userModel == null || string.IsNullOrEmpty(userModel.UserName) || string.IsNullOrEmpty(userModel.Passowrd))
            {
                return new BadRequestObjectResult("Invalid input data.");
            }
            //userModel.Passowrd = BCrypt.Net.BCrypt.HashPassword(userModel.Passrd);
            var userDetails = await _dc.User
            .FirstOrDefaultAsync(x => x.UserName == userModel.UserName && x.Passowrd == userModel.Passowrd);



            if (userDetails == null)
            {
                return new UnauthorizedObjectResult("Invalid username or password.");
            }

            return new OkObjectResult(new
            {
                Message = "Authentication successful.",
                User = userDetails
                // Token = token // Uncomment if a token is generated
            });

        }

    }
}
