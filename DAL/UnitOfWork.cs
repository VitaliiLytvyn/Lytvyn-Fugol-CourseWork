using DAL.Models;
using System;

namespace DAL
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly Context context;

        public ContextRepository<User> Users { get; }

        public ContextRepository<Tour> Tours { get; }

        public ContextRepository<City> Cities { get; }

        public ContextRepository<Hotel> Hotels { get; }


        private bool Disposed;

        public UnitOfWork(Context context, ContextRepository<User> users, ContextRepository<Tour> tours, ContextRepository<City> cities, ContextRepository<Hotel> hotels)
        {
            this.context = context;
            Users = users;
            Tours = tours;
            Cities = cities;
            Hotels = hotels;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Disposed) return;
            if (disposing)
            {
                context.Dispose();
            }

            Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
