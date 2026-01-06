using System;
using System.Collections.Generic;

namespace cessna.web.Models;

public partial class Rezervasyon
{
    public int RezervasyonKod { get; set; }

    public int YolcuKod { get; set; }

    public int UcusKod { get; set; }

    public DateTime? RezervasyonZamani { get; set; }

    public string? Sinif { get; set; }

    public string? OdemeDurumu { get; set; }

    public string? KoltukNo { get; set; }

    public virtual Ucu UcusKodNavigation { get; set; } = null!;

    public virtual Yolcu YolcuKodNavigation { get; set; } = null!;
}
