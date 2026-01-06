using System;
using System.Collections.Generic;

namespace cessna.web.Models;

public partial class Pilot
{
    public int PilotKod { get; set; }

    public string AdSoyad { get; set; } = null!;

    public string LisansNo { get; set; } = null!;

    public int? DeneyimYil { get; set; }

    public virtual ICollection<Ucu> Ucus { get; set; } = new List<Ucu>();
}
