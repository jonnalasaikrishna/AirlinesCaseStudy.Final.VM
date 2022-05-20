using AirlineAuthentication.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CommonDAL.Models;

namespace AirlineAuthentication.Models
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        //Dictionary<string, string> UserRecords = new Dictionary<string, string>
        //{
        //    { "user1","password1"},
        //     { "user2","password2"}
        //};

        private readonly IConfiguration configuartion;

        public JWTManagerRepository(IConfiguration iconfiguration)
        {
            configuartion = iconfiguration;
        }


        public Tokens Authenticate(AuthenticateUser users)
        {
            //if (!UserRecords.Any(x => x.Key == users.Name && x.Value == users.Password))
            //{
            //    return null;
            //}

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(configuartion["JWT:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,users.EmailId)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token),UserId=users.UserId,RoleId=users.RoleId };
        }
    }
}
