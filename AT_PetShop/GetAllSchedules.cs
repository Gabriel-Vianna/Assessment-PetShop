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
    public static class GetAllSchedules
    {
        [FunctionName("GetAllSchedules")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var scheduleRepository = new ScheduleRepository();

            var allSchedules = scheduleRepository.GetAllSchedules();

            return new OkObjectResult(allSchedules);
        }
    }
}
