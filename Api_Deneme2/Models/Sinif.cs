using System;
using System.Collections.Generic;

namespace Api_Deneme2.Models;

public partial class Sinif
{
    public int SınıfId { get; set; }

    public string SınıfAd { get; set; } = null!;

    public int SınıfKontenjan { get; set; }

    public int PersonelId { get; set; }

    public int KresId { get; set; }

    public bool? Aktif { get; set; }

    public virtual Kresler Kres { get; set; } = null!;

    public virtual ICollection<OgrenciBİlgİ> OgrenciBİlgİs { get; set; } = new List<OgrenciBİlgİ>();

    public virtual Personel Personel { get; set; } = null!;
}
