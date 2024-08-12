using System;
using System.Collections.Generic;

namespace Api_Deneme2.Models;

public partial class Personel
{
    public int PersonelId { get; set; }

    public string PersonelAd { get; set; } = null!;

    public string PersonelSoyad { get; set; } = null!;

    public string PersonelIletisim { get; set; } = null!;

    public string PersonelEMail { get; set; } = null!;

    public string PersonelAdres { get; set; } = null!;

    public string PersonelYetki { get; set; } = null!;

    public int KresId { get; set; }

    public bool? Aktif { get; set; }

    public virtual Kresler Kres { get; set; } = null!;

    public virtual ICollection<Sinif> Sinifs { get; set; } = new List<Sinif>();
}
