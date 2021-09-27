using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Infrastructure.ScheduleModel
{
    public class ScheduleModel
    {
        public Guid Id { get; set; }

        public string PetName { get; set; }

        public string PetBreed { get; set; }

        public DateTime SchedulingDate { get; set; }

        public string PetOwner { get; set; }

        public string PhoneNumber { get; set; }
    }
}
