using Infrastructure.ScheduleModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AT_PetShop.Web.RestClientSchedule
{
    public class ScheduleClient
    {
        private string URL_PET_REST = "https://at-petshop.azurewebsites.net/api";

        public IList<ScheduleModel> GetAll()
        {
            var client = new RestClient(URL_PET_REST);

            var request = new RestRequest("GetAllSchedules", DataFormat.Json);

            var response = client.Get<IList<ScheduleModel>>(request);

            return response.Data;
        }

        public ScheduleModel GetById(Guid id)
        {
            var client = new RestClient(URL_PET_REST);

            var request = new RestRequest($"GetScheduleById?id={id}", DataFormat.Json);    

            var response = client.Get<ScheduleModel>(request);

            return response.Data;
        }

        public void Save(ScheduleModel model)
        {
            var client = new RestClient(URL_PET_REST);
            var request = new RestRequest($"CreateSchedule", DataFormat.Json);
            request.AddJsonBody(model);

            var response = client.Post<ScheduleModel>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.Created)
                throw new Exception("Não consegui criar o agendamento");


        }

        public void Delete(Guid id)
        {
            var client = new RestClient(URL_PET_REST);

            var request = new RestRequest($"DeleteSchedule?id={id}", DataFormat.Json);

            //Outra forma de passar o parametro id
            //request.AddQueryParameter("id", id.ToString());            

            var response = client.Delete(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("Não consegui criar o agendamento");

        }

        public void Update(ScheduleModel model)
        {
            var client = new RestClient(URL_PET_REST);

            var request = new RestRequest($"UpdateSchedule", DataFormat.Json);
            request.AddJsonBody(model);

            var response = client.Put<ScheduleModel>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("Não consegui atualizar o agendamento");

        }
    }
}
