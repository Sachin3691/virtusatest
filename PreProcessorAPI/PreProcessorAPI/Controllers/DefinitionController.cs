using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PreProcessorAPI.Models;
using PreProcessorAPI.Services;

namespace PreProcessorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefinitionController : ControllerBase
    {
        private readonly IDefinitionService DefinitionService;
      

        public DefinitionController(IDefinitionService definitionService)
        {
            DefinitionService = definitionService;
           
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(DefinitionService.GetAll());
        }

        [HttpPost]
        public ActionResult Add(Definition definition) 
        {
            DefinitionService.Add(definition);
            return Created(string.Empty, definition);
        }

        [HttpDelete]
        public bool Delete(string Id)
        {
            return DefinitionService.Delete(Id);
        }
    }
}