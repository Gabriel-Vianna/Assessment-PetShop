using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Infrastructure;

namespace AT_PetShop
{
    public static class GetScheduleById
    {
        [FunctionName("GetScheduleById")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var id = new Guid(req.Query["id"]);

            var scheduleRepository = new ScheduleRepository();

            var result = scheduleRepository.GetById(id);

            if (result == null)
                return new NotFoundResult();

            return new OkObjectResult(result);
        }
    }
}
