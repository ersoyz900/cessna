using System;
using System.Collections.Generic;

namespace cessna.web.Models;

public partial class VW_UcusGenelBaki
{
    public int UcusKod { get; set; }

    public string UcusNo { get; set; } = null!;

    public DateTime? KalkisZamani { get; set; }

    public DateTime? VarisZamani { get; set; }

    public string? Durum { get; set; }

    public string UcakKuyrukNo { get; set; } = null!;

    public string UcakModel { get; set; } = null!;

    public string PilotAdi { get; set; } = null!;

    public string KalkisHavalimani { get; set; } = null!;

    public string VarisHavalimani { get; set; } = null!;
}
