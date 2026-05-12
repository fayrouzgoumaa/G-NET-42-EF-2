using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_42_EF_2.Models
{
    internal class Registeration
    {
        public int Id { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string? Note { get; set; }

        public string Tier { get; set; }

        // FK
        public int AttendeeId { get; set; }

        public Attendee Attendee { get; set; }

        // FK
        public int EventId { get; set; }

        public Event Event { get; set; }

        // One-to-One
        public Badge Badge { get; set; }
    }
}
