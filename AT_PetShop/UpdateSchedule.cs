using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Infrastructure.ScheduleModel;
using Infrastructure;

namespace AT_PetShop
{
    public static class UpdateSchedule
    {
        [FunctionName("UpdateSchedule")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            Schedule dataToUpdate = JsonConvert.DeserializeObject<Schedule>(requestBody);

            var scheduleRepository = new ScheduleRepository();

            await scheduleRepository.Update(dataToUpdate);

            return new OkObjectResult(dataToUpdate);
        }
    }
}
