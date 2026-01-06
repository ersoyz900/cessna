using System;
using System.Collections.Generic;

namespace cessna.web.Models;

public partial class Hoste
{
    public int HostesKod { get; set; }

    public string AdSoyad { get; set; } = null!;

    public int? DeneyimYil { get; set; }

    public string? Vardiya { get; set; }

    public virtual ICollection<Ucu> UcusKods { get; set; } = new List<Ucu>();
}
