using System;
using System.Collections.Generic;

namespace cessna.web.Models;

public partial class Ucak
{
    public int UcakKod { get; set; }

    public string KuyrukNo { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string? Uretici { get; set; }

    public int? Kapasite { get; set; }

    public int? UretimYili { get; set; }

    public virtual ICollection<HazirlikKontrol> HazirlikKontrols { get; set; } = new List<HazirlikKontrol>();

    public virtual ICollection<Koltuk> Koltuks { get; set; } = new List<Koltuk>();

    public virtual ICollection<Ucu> Ucus { get; set; } = new List<Ucu>();
}
