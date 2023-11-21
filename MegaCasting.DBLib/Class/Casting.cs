using System;
using System.Collections.Generic;

namespace MegaCasting.DBLib.Class;

public partial class Casting
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public string Libelle { get; set; } = null!;

    public DateTime Date { get; set; }

    public int AdresseId { get; set; }

    public int DiffuseurId { get; set; }

    public virtual Adresse Adresse { get; set; } = null!;

    public virtual Diffuseur Diffuseur { get; set; } = null!;
}
