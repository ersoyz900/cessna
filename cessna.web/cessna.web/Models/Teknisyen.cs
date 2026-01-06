using System;
using System.Collections.Generic;

namespace cessna.web.Models;

public partial class Teknisyen
{
    public int TeknisyenKod { get; set; }

    public string AdSoyad { get; set; } = null!;

    public string? Gorev { get; set; }

    public string? Vardiya { get; set; }

    public string? Eposta { get; set; }

    public virtual ICollection<HazirlikKontrol> HazirlikKontrols { get; set; } = new List<HazirlikKontrol>();

    public virtual ICollection<Yakit> Yakits { get; set; } = new List<Yakit>();
}
