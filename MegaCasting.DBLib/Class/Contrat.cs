using System;
using System.Collections.Generic;

namespace MegaCasting.DBLib.Class;

public partial class Contrat
{
    public int Id { get; set; }

    public string? Libelle { get; set; }

    public DateTime DateDebut { get; set; }

    public DateTime DateFin { get; set; }
}
