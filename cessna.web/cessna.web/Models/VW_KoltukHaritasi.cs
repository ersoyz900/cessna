using System;
using System.Collections.Generic;

namespace cessna.web.Models;

public partial class VW_KoltukHaritasi
{
    public int UcakKod { get; set; }

    public string KuyrukNo { get; set; } = null!;

    public string KoltukNo { get; set; } = null!;

    public string? KoltukTipi { get; set; }

    public int? DizMesafesi { get; set; }
}
