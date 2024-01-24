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
    public async Task<ActionResult<IEnumerable<Funcionario>>> GetFuncionariosAsync()
    {
        try
        {
            var funcionarios = await _context.Funcionarios.AsNoTracking().ToListAsync();

            return funcionarios;
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }

    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Funcionario>> GetFuncionarioAsync(int id)
    {
        try
        {
            var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(x => x.FuncionarioId == id);

            if (funcionario is null)
            {
                return NotFound();
            }

            return Ok(funcionario);
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
        

        
    }
}
