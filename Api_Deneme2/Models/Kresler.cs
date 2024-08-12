using System;
using System.Collections.Generic;

namespace Api_Deneme2.Models;

public partial class Kresler
{
    public int KresId { get; set; }

    public string KresAd { get; set; } = null!;

    public string KresAdres { get; set; } = null!;

    public int KresKontenjan { get; set; }

    public string? Kresİletisim { get; set; }

    public bool? Aktif { get; set; }

    public virtual ICollection<OgrenciBİlgİ> OgrenciBİlgİs { get; set; } = new List<OgrenciBİlgİ>();

    public virtual ICollection<Personel> Personels { get; set; } = new List<Personel>();

    public virtual ICollection<Sinif> Sinifs { get; set; } = new List<Sinif>();
}
