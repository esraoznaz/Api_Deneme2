namespace Api_Deneme2.Models
{
	public class YetkiEkleDto
	{
		public int YetkiId { get; set; }

		public string YetkiTuru { get; set; } = null!;

		public string YetkiliAd { get; set; } = null!;

		public string YetkiliIletisim { get; set; } = null!;

		public string YetkiliAdres { get; set; } = null!;

		public string YetkiliEMail { get; set; } = null!;

		public string YetkiliSifre { get; set; } = null!;

		public bool? Aktif { get; set; }

		public int? KresId { get; set; }
	}
}
