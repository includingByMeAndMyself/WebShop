using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api.Model;
using Microsoft.IdentityModel.Tokens;

namespace Api.Service;

public class JwtTokenGenerator
{
    private readonly string _secretKey;
    
    public JwtTokenGenerator(IConfiguration configuration)
    {
        var token = configuration["AuthSettings:SecretKey"];
        _secretKey = token ?? "const_secret_key_const_secret_key_const_secret_key_const_secret_key_const_secret_key";
    }

    public string GenerateJwtToken(AppUser user, IList<string> roles)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secretKey);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("id", user.Id),
                new Claim(ClaimTypes.Email, user.UserName),
                new Claim(ClaimTypes.Role, string.Join(",", roles))
            }),
            
            Expires = DateTime.UtcNow.AddDays(1),
            
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}