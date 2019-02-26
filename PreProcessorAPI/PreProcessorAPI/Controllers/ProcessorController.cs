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
    public class ProcessorController : ControllerBase
    {
        private readonly IDefinitionService DefinitionService;
        private readonly IDataService DataService;
        private const string delimiter = "|";

        public ProcessorController(IDefinitionService definitionService, IDataService dataService)
        {
            DefinitionService = definitionService;
            DataService = dataService;
        }

        [HttpGet]
        public async Task<ActionResult> GetCountry(string inputData)
        {
            if(!inputData.Substring(0).Contains(delimiter))
            {
                return BadRequest("Invalid data. Data must contain '|'");
            }
            List<string> data = inputData.Split(delimiter).ToList();
            List<string> formatDataList = new List<string>();
            if (data.Count > 1)
            {
                List<Definition> rules = DefinitionService.GetAll();

                

                foreach (var rule in rules)
                {
                   data.ForEach(r => formatDataList.Add(r.Replace(rule.Target, rule.Replace)));
                }
            }

            await DataService.GetData(formatDataList);

            return Ok();
        }
    }
}