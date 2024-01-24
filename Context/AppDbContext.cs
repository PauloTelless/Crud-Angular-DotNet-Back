using Crud_Angular_DotNet_Back.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud_Angular_DotNet_Back.Context;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<Funcionario> Funcionarios { get; set; }
}
