using Crud_Angular_DotNet_Back.Context;
using Crud_Angular_DotNet_Back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crud_Angular_DotNet_Back.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FuncionariosController : ControllerBase
{
    private readonly AppDbContext _context;
    public FuncionariosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Funcionario>>> GetFuncionarios()
    {
        var funcionarios = await _context.Funcionarios.AsNoTracking().ToListAsync();

        return funcionarios;
    }
}
