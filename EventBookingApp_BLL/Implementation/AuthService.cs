﻿using EventBookingApp_BLL.Interface;
using EventBookingApp_Contracts;
using EventBookingApp_DAL.Dtos.Response;
using EventBookingApp_DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingApp_BLL.Implementation
{

    public sealed class AuthService : IAuthService
    {
        /*private readonly ILoggerManager _logger;*/
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private User? _user;
        private readonly IUnitOfWork _unitOfWork;
   


        public AuthService(UserManager<User> userManager, IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            /*_logger = logger;*/
            _userManager = userManager;
            
            
         
            _configuration = configuration;
        }



        public async Task<ServiceResponse<string>> ValidateUser(UserAuthenticationResponse response)
        {
            

            _user = await _userManager.FindByNameAsync(response.UserName);

            var result = _user != null && await _userManager.CheckPasswordAsync(_user, response.Password);
            if (!result)
            {
               

                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = "Login failed. Wrong username or password."
                };
            }

            var role = (await _userManager.GetRolesAsync(_user))[0];
            return new ServiceResponse<string>
            {
                Success = true,
                Message = "Login successful.",

                Role = role
            };
        }



        public async Task<string> CreateToken()
        {

            /* _logger.LogInfo("Creates the JWT token");*/

            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();


            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        }


        private SigningCredentials GetSigningCredentials()
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["Secret"]);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, _user.Id.ToString()),
                new Claim(ClaimTypes.Name, _user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, _user.Id.ToString()),

            };

            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken
            (
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
            signingCredentials: signingCredentials
            );
            return tokenOptions;
        }

       

        public async Task<JwtToken> GenerateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();

            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            return new JwtToken
            {
                Token = new JwtSecurityTokenHandler().WriteToken(tokenOptions),
                Issued = tokenOptions.ValidFrom,
                Expires = tokenOptions.ValidTo
            };
        }


    }
}
