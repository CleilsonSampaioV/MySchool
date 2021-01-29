using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MySchool.Infra.Data.Repositories.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MySchool.Ui.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : Base.BaseController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SchoolController(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: api/<SchoolController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SchoolController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SchoolController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SchoolController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SchoolController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
