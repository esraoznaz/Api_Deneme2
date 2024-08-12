using System;
using System.Collections.Generic;

namespace Api_Deneme2.Models;

public partial class OgrenciBİlgİ
{
    public int OgrenciId { get; set; }

    public string OgrenciAd { get; set; } = null!;

    public string OgrenciSoyad { get; set; } = null!;

    public string OgrenciYas { get; set; } = null!;

    public string OgrenciCinsiyet { get; set; } = null!;

    public int OgrenciSınıfId { get; set; }

    public string VeliAdı { get; set; } = null!;

    public string VeliIletisim { get; set; } = null!;

    public string OrenciAdres { get; set; } = null!;

    public int KresId { get; set; }

    public bool? Aktif { get; set; }

    public virtual Kresler Kres { get; set; } = null!;

    public virtual Sinif OgrenciSınıf { get; set; } = null!;
}
