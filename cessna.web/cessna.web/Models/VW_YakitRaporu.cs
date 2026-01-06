using System;
using System.Collections.Generic;

namespace cessna.web.Models;

public partial class VW_YakitRaporu
{
    public int YakitKod { get; set; }

    public int UcusKod { get; set; }

    public string UcusNo { get; set; } = null!;

    public double? MiktarLitre { get; set; }

    public double? BirimFiyat { get; set; }

    public double ToplamTutar { get; set; }

    public int TeknisyenKod { get; set; }
}
