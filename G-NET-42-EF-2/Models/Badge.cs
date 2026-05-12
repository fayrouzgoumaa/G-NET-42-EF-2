using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_42_EF_2.Models
{
    internal class Badge
    {
        public int Id { get; set; }

        public string BadgeCode { get; set; }

        public DateTime IssuedAt { get; set; }

        // FK
        public int RegistrationId { get; set; }

        public Registeration Registration { get; set; }
    }
}
