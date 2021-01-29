﻿using Microsoft.AspNetCore.Mvc;
using MySchool.Domain.Commands;
using MySchool.Domain.Commands.School;
using MySchool.Domain.Handlers;
using MySchool.Domain.Queries;
using MySchool.Infra.Data.Repositories.Transactions;
using System;
using System.Threading.Tasks;

namespace MySchool.Ui.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : Base.BaseController
    {
        public SchoolController(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        [HttpGet]
        public async Task<IActionResult> Get([FromServices] SchoolQueries schoolQueries)
        {
            return Ok(schoolQueries.GetAll().Result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id, [FromServices] SchoolQueries schoolQueries)
        {
            return Ok(schoolQueries.Get(Guid.Parse(id)).Result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddSchoolCommand command, [FromServices] SchoolHandler handler)
        {
            return await ResponseAsync((CommandResult)handler.Handle(command).Result);
        }

        [HttpPatch()]
        [Route("UpdateName")]
        public async Task<IActionResult> Put([FromBody] UpdateNameSchoolCommand command, [FromServices] SchoolHandler handler)
        {
            return await ResponseAsync((CommandResult)handler.Handle(command).Result);
        }

        [HttpPatch()]
        [Route("UpdateAddress")]
        public async Task<IActionResult> Put([FromBody] UpdateAddressSchoolCommand command, [FromServices] SchoolHandler handler)
        {
            return await ResponseAsync((CommandResult)handler.Handle(command).Result);
        }

        [HttpDelete()]
        public async Task<IActionResult> Delete([FromBody] RemoveSchoolCommand command, [FromServices] SchoolHandler handler)
        {
            return await ResponseAsync((CommandResult)handler.Handle(command).Result);
        }
    }
}
