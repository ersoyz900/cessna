using System;
using System.Collections.Generic;

namespace cessna.web.Models;

public partial class VW_YolcuRezervasyonlari
{
    public int RezervasyonKod { get; set; }

    public int YolcuKod { get; set; }

    public string YolcuAdi { get; set; } = null!;

    public string UcusNo { get; set; } = null!;

    public string? KoltukNo { get; set; }

    public string? Sinif { get; set; }

    public string? OdemeDurumu { get; set; }

    public DateTime? RezervasyonZamani { get; set; }
}
