using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySchool.Domain.Commands;
using MySchool.Domain.Commands.Class;
using MySchool.Domain.Handlers;
using MySchool.Domain.Queries;
using MySchool.Infra.Data.Repositories.Transactions;

namespace MySchool.Ui.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController: Base.BaseController
    {
        public ClassController(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        [HttpGet]
        [Route("GetAllClassBySchoolId/{id}")]
        public async Task<IActionResult> GetAllClassBySchoolId(string id,[FromServices] ClassQueries schoolQueries)
        {
            return Ok(schoolQueries.GetAllClassBySchoolId(Guid.Parse(id)).Result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id, [FromServices] ClassQueries schoolQueries)
        {
            return Ok(schoolQueries.Get(Guid.Parse(id)).Result);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] AddClassCommand command, [FromServices] ClassHandler handler)
        {
            return await ResponseAsync((CommandResult)handler.Handle(command).Result);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateNameClassCommand command, [FromServices] ClassHandler handler)
        {
            return await ResponseAsync((CommandResult)handler.Handle(command).Result);
        }

        //[HttpPatch()]
        //[Route("UpdateShift")]
        //public async Task<IActionResult> Put([FromBody] UpdateShiftClassCommand command, [FromServices] ClassHandler handler)
        //{
        //    return await ResponseAsync((CommandResult)handler.Handle(command).Result);
        //}

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id,[FromServices] ClassHandler handler)
        {
            return await ResponseAsync((CommandResult)handler.Handle(id).Result);
        }
    }
}
