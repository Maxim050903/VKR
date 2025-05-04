using Core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class JwtReader
    {
        private readonly HttpContext _context; 

        public JwtReader(HttpContext context)
        {
            _context = context;
        }

        public Guid TakeId()
        {
            string token = _context.Request.Cookies["token"];

            var handler = new JwtSecurityTokenHandler();

            var jwttoken = handler.ReadJwtToken(token);

            var id = Guid.Parse(jwttoken.Claims.First(x => x.Type == "UserId").Value);

            return id;
        }
    }
}
