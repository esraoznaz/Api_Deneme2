using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api_Deneme2.Models;
using Api_Deneme2.Data;
using Microsoft.AspNetCore.Authorization;




namespace Api_Deneme2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize (Roles ="Yönetici")]
	public class YetkiController : ControllerBase
	{
		private readonly KresContext dbContext;

		public YetkiController(KresContext dbContext) 
		{ 
			this.dbContext=dbContext;
		}
		[HttpGet]
		public IActionResult GetYetki() 
		{
			var yetki = dbContext.Yetkis.ToList();
			return Ok(yetki);
		}
		[HttpGet]
		[Route("{YetkiId:int}")]
		public IActionResult GetYetkiById(int YetkiId) 
		{ 
			var yetki= dbContext.Yetkis.Find(YetkiId);
			if (yetki == null)
			{
				return NotFound();
			}
			return Ok(yetki);
		}
		[HttpPost]

		public IActionResult EkleYetkili(YetkiEkleDto yetkiEkleDto)
		{
			var yetkiekle = new Yetki()
			{
				YetkiId = yetkiEkleDto.YetkiId,
				YetkiTuru = yetkiEkleDto.YetkiTuru,
				YetkiliAd = yetkiEkleDto.YetkiliAd,
				YetkiliIletisim = yetkiEkleDto.YetkiliIletisim,
				YetkiliAdres = yetkiEkleDto.YetkiliAdres,
				YetkiliEMail = yetkiEkleDto.YetkiliEMail,
				YetkiliSifre = yetkiEkleDto.YetkiliSifre,
				Aktif = yetkiEkleDto.Aktif,
				KresId = yetkiEkleDto.KresId
			};
			dbContext.Yetkis.Add(yetkiekle);
			dbContext.SaveChanges();
			return Ok(yetkiekle);
		}

		[HttpPut]
		[Route("{YetkiId:int}")]
		public IActionResult GuncelleYetkiliById(int YetkiId, YetkiliGuncelleDto yetkiliGuncelleDto)
		{
			var yetkiliGuncel= dbContext.Yetkis.Find(YetkiId);
			if (yetkiliGuncel == null)
			{
				return NotFound();
			}

			yetkiliGuncel.YetkiliAd = yetkiliGuncelleDto.YetkiliAd;
			yetkiliGuncel.YetkiliIletisim = yetkiliGuncelleDto.YetkiliIletisim;
			yetkiliGuncel.YetkiliAdres = yetkiliGuncelleDto.YetkiliAdres;
			yetkiliGuncel.YetkiliEMail = yetkiliGuncelleDto.YetkiliEMail;
			yetkiliGuncel.YetkiliSifre = yetkiliGuncelleDto.YetkiliSifre;
			yetkiliGuncel.Aktif = yetkiliGuncelleDto.Aktif;
			yetkiliGuncel.KresId = yetkiliGuncelleDto.KresId;

			dbContext.SaveChanges();
			return Ok(yetkiliGuncel);

		}

		[HttpDelete]
		[Route("{YetkiliId:int}")]

		public IActionResult YetkiliSilById(int YetkiliId)
		{
			var yetkiliSil = dbContext.Yetkis.Find(YetkiliId);
			if (yetkiliSil == null)
			{
				return NotFound();
			}
			dbContext.Yetkis.Remove(yetkiliSil);
			dbContext.SaveChanges();
			return Ok(yetkiliSil);
		}


	}
}
 