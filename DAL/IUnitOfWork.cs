using DAL.Models;

namespace DAL
{
    public interface IUnitOfWork
    {
        ContextRepository<User> Users { get; }

        ContextRepository<Tour> Tours { get; }

        ContextRepository<City> Cities { get; }

        ContextRepository<Hotel> Hotels { get; }

        void Save();
        void Dispose();
    }
}
