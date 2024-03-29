﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Crud_Angular_DotNet_Back.Models;

[Table("Funcionarios")]
public class Funcionario
{
    [JsonIgnore]
    [Key]
    public int FuncionarioId { get; set; }

    [Required, StringLength(80)]
    public string? NomeFuncionario { get; set; }

    [Required, StringLength(80)]
    public string? Cargo { get; set; }

    [Required, Range(1, 100)]
    public int IdadeFuncionario { get; set; }

    [Required]
    public bool IsActive { get; set; }

}
