using G_NET_42_EF_2.Data;
using G_NET_42_EF_2.Models;

namespace G_NET_42_EF_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using AppDbContext context = new AppDbContext();
            Organizer organizer = new Organizer
            {
                Name = "Fayrouz Goumaa",
                CompanyName = "Route",
                IsVerified = true
            };
            organizer.Profile = new OrganizerProfile
            {
                Bio = "Technology ",
                Website = "www.route.com",
                LogoUrl = "logo.png"
            };
            Event mainEvent = new Event
            {
                Title = "Tech 2026",
                Description = "sdfghyjhkl;'l",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(2),
                MaxAttendees = 500,

                Organizer = organizer,

                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            Attendee attendee = new Attendee
            {
                FullName = "Sara Mohamed",

                Email = "sara@gmail.com",

                Address = new Address
                {
                    Street = "10 Nile Street",
                    City = "Mansoura",
                    Country = "Egypt",
                    PostalCode = "35511"
                }
            };
            Registeration registration = new Registeration
            {
                RegistrationDate = DateTime.Now,

                Tier = "VIP",

                Note = "Looking forward to attending",

                Event = mainEvent,

                Attendee = attendee
            };
            registration.Badge = new Badge
            {
                BadgeCode = "VIP-001",

                IssuedAt = DateTime.Now
            };
            context.Registrations.Add(registration);
            context.SaveChanges();
            Console.WriteLine("Data Inserted Successfully");
        }
    }
}
