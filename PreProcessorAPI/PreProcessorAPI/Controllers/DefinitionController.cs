using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PreProcessorAPI.DB;

namespace PreProcessorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefinitionController : ControllerBase
    {
        private readonly IDefinitionService DefinitionService;

        public DefinitionController(IDefinitionService definitionService)
        {
            this.DefinitionService = definitionService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(await DefinitionService.GetAll());
        }
    }
}