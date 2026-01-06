using System;
using System.Collections.Generic;

namespace cessna.web.Models;

public partial class HazirlikKontrol
{
    public int TeknisyenKod { get; set; }

    public int UcakKod { get; set; }

    public int UcusKod { get; set; }

    public DateTime? HazirlikZamani { get; set; }

    public string? Notlar { get; set; }

    public virtual Teknisyen TeknisyenKodNavigation { get; set; } = null!;

    public virtual Ucak UcakKodNavigation { get; set; } = null!;

    public virtual Ucu UcusKodNavigation { get; set; } = null!;
}
