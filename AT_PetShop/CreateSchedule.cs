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
    public static class CreateSchedule
    {
        [FunctionName("CreateSchedule")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            Schedule data = JsonConvert.DeserializeObject<Schedule>(requestBody);
            data.Id = Guid.NewGuid();

            var scheduleRepository = new ScheduleRepository();

            await scheduleRepository.Create(data);

            return new CreatedResult($"", data);
        }
    }
}
