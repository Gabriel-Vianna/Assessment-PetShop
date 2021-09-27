using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Infrastructure.ScheduleModel
{
    public class Schedule
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "petName")]
        public string PetName { get; set; }

        [JsonProperty(PropertyName = "petBreed")]
        public string PetBreed { get; set; }

        [JsonProperty(PropertyName = "schedulingDate")]
        public DateTime SchedulingDate { get; set; }

        [JsonProperty(PropertyName = "petOwner")]
        public string PetOwner { get; set; }

        [JsonProperty(PropertyName = "phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "pk")]
        public string PartitionKey { get; set; } = "scheduling";

    }
}
