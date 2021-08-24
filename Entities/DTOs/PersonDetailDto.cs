using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class PersonDetailDto:IDto
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string PersonSurname { get; set; }
        public string PersonPhoneNumber { get; set; }
        public string PersonEmail { get; set; }
    } 
}
