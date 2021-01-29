using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using MySchool.Domain.Commands;
using MySchool.Infra.Data.Repositories.Transactions;

namespace MySchool.Ui.Api.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> ResponseAsync(CommandResult commandResult)
        {
            if (commandResult.Success)
            {
                try
                {
                    _unitOfWork.SaveChanges();

                    return Ok(commandResult);
                }
                catch (Exception ex)
                {
                    // Aqui devo logar o erro
                    return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
                    //return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
                }
            }
            else
            {
                return Ok(commandResult);
            }
        }

        public async Task<IActionResult> ResponseExceptionAsync(Exception ex)
        {
            return BadRequest(new { errors = ex.Message, exception = ex.ToString() });
            //return Request.CreateResponse(HttpStatusCode.InternalServerError, new { errors = ex.Message, exception = ex.ToString() });
        }
    }
}
