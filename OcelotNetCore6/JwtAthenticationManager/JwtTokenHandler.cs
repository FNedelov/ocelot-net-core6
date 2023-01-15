using JwtAthenticationManager.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAthenticationManager
{
    public class JwtTokenHandler
    {
        public const string JWT_SECURITY_KEY = "secret-security-key";
        private const int JWT_TOKEN_VALIDITY_MINS = 20;
        private readonly List<UserAccount> _userAccountList;

        public JwtTokenHandler()
        {
            _userAccountList = new()
            {
                new UserAccount{UserName = "Admin", Password = "admin123", Role = "Administrator"},
                new UserAccount{UserName = "user01", Password = "user01", Role = "User"}
            };
        }

        public async Task<AuthenticationResponse?> GenerateJwtToken(AuthenticationRequest authenticationRequest)
        {
            await Task.Delay(1);
            if (string.IsNullOrWhiteSpace(authenticationRequest.UserName) || string.IsNullOrEmpty(authenticationRequest.Password)) 
                return null;

            var userAccount = _userAccountList.Where(x => x.UserName == authenticationRequest.UserName && x.Password == authenticationRequest.Password).FirstOrDefault();
            if (userAccount == null) return null;

            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            ClaimsIdentity claimsIdentity = new(new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, authenticationRequest.UserName),
                new Claim(ClaimTypes.Role, userAccount.Role)
            });

            SigningCredentials signingCredentials = new(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor securityTokenDescriptor = new()
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return new AuthenticationResponse
            {
                UserName = userAccount.UserName,
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds,
                JwtToken = token
            };
        }
    }
}