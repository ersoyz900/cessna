using System;
using System.Collections.Generic;

namespace cessna.web.Models;

public partial class Yolcu
{
    public int YolcuKod { get; set; }

    public string AdSoyad { get; set; } = null!;

    public string? Cinsiyet { get; set; }

    public DateOnly? DogumTarihi { get; set; }

    public string? Eposta { get; set; }

    public string? Telefon { get; set; }

    public string PasaportNo { get; set; } = null!;

    public virtual ICollection<Rezervasyon> Rezervasyons { get; set; } = new List<Rezervasyon>();
}
