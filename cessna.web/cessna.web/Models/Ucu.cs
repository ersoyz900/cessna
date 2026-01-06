using System;
using System.Collections.Generic;

namespace cessna.web.Models;

public partial class Ucu
{
    public int UcusKod { get; set; }

    public string UcusNo { get; set; } = null!;

    public DateTime? KalkisZamani { get; set; }

    public DateTime? VarisZamani { get; set; }

    public string? Durum { get; set; }

    public int? UcakKod { get; set; }

    public int? PilotKod { get; set; }

    public int? KalkisHavalimaniKod { get; set; }

    public int? VarisHavalimaniKod { get; set; }

    public virtual ICollection<HazirlikKontrol> HazirlikKontrols { get; set; } = new List<HazirlikKontrol>();

    public virtual Havalimani? KalkisHavalimaniKodNavigation { get; set; }

    public virtual Pilot? PilotKodNavigation { get; set; }

    public virtual ICollection<Rezervasyon> Rezervasyons { get; set; } = new List<Rezervasyon>();

    public virtual Ucak? UcakKodNavigation { get; set; }

    public virtual Havalimani? VarisHavalimaniKodNavigation { get; set; }

    public virtual ICollection<Yakit> Yakits { get; set; } = new List<Yakit>();

    public virtual ICollection<Hoste> HostesKods { get; set; } = new List<Hoste>();
}
