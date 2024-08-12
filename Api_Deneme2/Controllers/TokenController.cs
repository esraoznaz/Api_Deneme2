using Api_Deneme2.Models;
using Api_Deneme2.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace Api_Deneme2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TokenController : ControllerBase
    {
        private readonly JwtAyarlari _jwtAyarlari;
        private readonly KresContext _context;
        public TokenController(IOptions<JwtAyarlari> jwtAyarlari, KresContext context)
        {
            _jwtAyarlari = jwtAyarlari.Value;
            _context = context;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Giris([FromBody]Yetki yetki)
        {
            var yetkii = KimlikDenetimiYap(yetki);
            if (yetkii == null)
            {
                return NotFound("Kullanıcı Bulunamadı.");
            }

            var token =TokenOlustur(yetkii);
            return Ok(token);

        }

        private string TokenOlustur(Yetki yetkii)
        {
            if(_jwtAyarlari.Key == null)
            {
                throw new Exception("Jwt ayarlarınındaki Key değeri null olmaz");
            }
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtAyarlari.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claimDizisi = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,yetkii.YetkiliEMail),
                new Claim(ClaimTypes.Role,yetkii.YetkiTuru!)
            };
            var token =new JwtSecurityToken(_jwtAyarlari.Issuer,
                _jwtAyarlari.Audience,
                claimDizisi,
                expires:DateTime.Now.AddHours(1),
                signingCredentials:credentials); 
            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        private Yetki KimlikDenetimiYap(Yetki yetki)
        {
            return _context.Yetkis.FirstOrDefault(x => x.YetkiliEMail.ToLower() == yetki.YetkiliEMail && x.YetkiliSifre == yetki.YetkiliSifre);
        }
    }
}
