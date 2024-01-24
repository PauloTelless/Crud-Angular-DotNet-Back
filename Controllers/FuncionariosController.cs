using Crud_Angular_DotNet_Back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud_Angular_DotNet_Back.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FuncionariosController : ControllerBase
{
    [HttpGet]
    public Task<ActionResult<IEnumerable<Funcionario>>> GetFuncionarios()
    {

    }
}
