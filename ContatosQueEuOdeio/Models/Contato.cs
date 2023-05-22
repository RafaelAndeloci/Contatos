using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ContatosQueEuOdeio.Models;

[PrimaryKey("Id", "IdCliente")]
[Table("Contato")]
public partial class Contato
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Perfil { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Tipo { get; set; }

    [Key]
    public int IdCliente { get; set; }

    [ForeignKey("IdCliente")]
    [InverseProperty("Contatos")]
    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
