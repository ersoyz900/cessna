using System;
using System.Collections.Generic;

namespace cessna.web.Models;

public partial class Yakit
{
    public int YakitKod { get; set; }

    public int UcusKod { get; set; }

    public int TeknisyenKod { get; set; }

    public double? MiktarLitre { get; set; }

    public double? BirimFiyat { get; set; }

    public double ToplamTutar { get; set; }

    public virtual Teknisyen TeknisyenKodNavigation { get; set; } = null!;

    public virtual Ucu UcusKodNavigation { get; set; } = null!;
}
