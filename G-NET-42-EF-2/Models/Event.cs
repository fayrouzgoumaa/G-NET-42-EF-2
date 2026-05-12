using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_42_EF_2.Models
{
    internal class Event
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int MaxAttendees { get; set; }

        // Organizer Relationship
        public int OrganizerId { get; set; }

        public Organizer Organizer { get; set; }

        // Self Relationship
        public int? ParentEventId { get; set; }

        public Event ParentEvent { get; set; }

        public ICollection<Event> Sessions { get; set; }
            = new List<Event>();

        // Many-to-Many
        public ICollection<Registration> Registrations { get; set; }
            = new List<Registration>();

        // Audit Fields
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
