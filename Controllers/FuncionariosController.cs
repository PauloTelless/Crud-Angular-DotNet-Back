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

    [HttpPost]
    public async Task<ActionResult<Funcionario>> PostFuncionarioAsync(Funcionario funcionario)
    {
        try
        {
            _context.Funcionarios.Add(funcionario);

            await _context.SaveChangesAsync();

            return Ok(funcionario);
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Funcionario>> PutFuncionarioAsync(int id, Funcionario funcionario)
    {
        try
        {
            var funcionarioId = await _context.Funcionarios.FirstOrDefaultAsync(x => x.FuncionarioId == id);
            if (funcionarioId is null)
            {
                return NotFound();
            }

            funcionarioId.NomeFuncionario = funcionario.NomeFuncionario;
            funcionarioId.Cargo = funcionario.Cargo;
            funcionarioId.IdadeFuncionario = funcionario.IdadeFuncionario;
            funcionarioId.IsActive = funcionario.IsActive;

            _context.Update(funcionarioId);

            await _context.SaveChangesAsync();

            return Ok(funcionarioId);
            
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }

    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Funcionario>> DeleteAsync(int id)
    {
        try
        {
            var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(x => x.FuncionarioId == id);

            if (funcionario is null)
            {
                return NotFound();
            }

            _context.Funcionarios.Remove(funcionario);

            await _context.SaveChangesAsync();

            return funcionario;

        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }
}
