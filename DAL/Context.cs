using DAL.Models;
using System.Data.Entity;

namespace DAL
{
    public class Context : DbContext
    {
        public Context()
           : base("name=TravelDatabase")
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Tour> Tours { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Hotel> Hotels { get; set; }

    }
}
