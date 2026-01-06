using System;
using System.Collections.Generic;

namespace cessna.web.Models;

public partial class Havalimani
{
    public int HavalimaniKod { get; set; }

    public string IATAKodu { get; set; } = null!;

    public string Ad { get; set; } = null!;

    public string? Sehir { get; set; }

    public string? Ulke { get; set; }

    public virtual ICollection<Ucu> UcuKalkisHavalimaniKodNavigations { get; set; } = new List<Ucu>();

    public virtual ICollection<Ucu> UcuVarisHavalimaniKodNavigations { get; set; } = new List<Ucu>();
}
