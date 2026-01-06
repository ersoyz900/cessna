using System;
using System.Collections.Generic;

namespace cessna.web.Models;

public partial class Koltuk
{
    public int UcakKod { get; set; }

    public string KoltukNo { get; set; } = null!;

    public string? KoltukTipi { get; set; }

    public int? DizMesafesi { get; set; }

    public virtual Ucak UcakKodNavigation { get; set; } = null!;
}
