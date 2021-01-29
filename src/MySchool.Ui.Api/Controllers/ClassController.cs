using Microsoft.AspNetCore.Mvc;
using MySchool.Domain.Commands;
using MySchool.Domain.Commands.Class;
using MySchool.Domain.Handlers;
using MySchool.Domain.Queries;
using MySchool.Infra.Data.Repositories.Transactions;
using System;
using System.Threading.Tasks;

namespace MyClass.Ui.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController: MySchool.Ui.Api.Controllers.Base.BaseController
    {
        public ClassController(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        [HttpGet]
        public async Task<IActionResult> Get([FromServices] ClassQueries schoolQueries)
        {
            return Ok(schoolQueries.GetAll().Result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id, [FromServices] ClassQueries schoolQueries)
        {
            return Ok(schoolQueries.Get(Guid.Parse(id)).Result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddClassCommand command, [FromServices] ClassHandler handler)
        {
            return await ResponseAsync((CommandResult)handler.Handle(command).Result);
        }

        [HttpPatch()]
        [Route("UpdateName")]
        public async Task<IActionResult> Put([FromBody] UpdateNameClassCommand command, [FromServices] ClassHandler handler)
        {
            return await ResponseAsync((CommandResult)handler.Handle(command).Result);
        }

        [HttpPatch()]
        [Route("UpdateShift")]
        public async Task<IActionResult> Put([FromBody] UpdateShiftClassCommand command, [FromServices] ClassHandler handler)
        {
            return await ResponseAsync((CommandResult)handler.Handle(command).Result);
        }

        [HttpDelete()]
        public async Task<IActionResult> Delete([FromBody] RemoveClassCommand command, [FromServices] ClassHandler handler)
        {
            return await ResponseAsync((CommandResult)handler.Handle(command).Result);
        }
    }
}
