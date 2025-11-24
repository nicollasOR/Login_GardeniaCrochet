using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Login.Models;

[Table("Cliente2")]
[Index("Email", Name = "UQ__Cliente2__A9D10534F7D2FE6B", IsUnique = true)]
[Index("Cpf", Name = "UQ__Cliente2__C1F897318CB6422F", IsUnique = true)]
public partial class Cliente2
{
    [Key]
    [Column("ID_Cliente")]
    public int IdCliente { get; set; }

    [StringLength(85)]
    [Unicode(false)]
    public string NomeCompleto { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [MaxLength(32)]
    public byte[] SenhaHash { get; set; } = null!;

    [StringLength(14)]
    public string Telefone { get; set; } = null!;

    [Column("CPF")]
    [StringLength(14)]
    [Unicode(false)]
    public string Cpf { get; set; } = null!;
}
