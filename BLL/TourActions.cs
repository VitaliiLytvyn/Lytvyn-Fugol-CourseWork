using AutoMapper;
using BLL.Models;
using DAL;
using DAL.Models;
using System.Collections.Generic;

namespace BLL
{
    public class TourActions
    {
        IMapper TourM = new MapperConfiguration(cfg => cfg.CreateMap<Tour, MTour>().
        ForMember(x => x.Hotel, y => y.MapFrom(c => c.Hotel))).CreateMapper();

        private readonly UnitOfWork uow;
        public TourActions(UnitOfWork uow)
        {
            this.uow = uow;
        }

        public TourActions()
        {
            Context context = new Context();
            uow = new UnitOfWork(context,
                new ContextRepository<User>(context), new ContextRepository<Tour>(context), new ContextRepository<City>(context), new ContextRepository<Hotel>(context));
        }


        public virtual List<MTour> GetTours()
        {
            return TourM.Map<IEnumerable<Tour>, List<MTour>>(uow.Tours.Get());
        }

        public virtual MTour GetTourById(int id)
        {
            return TourM.Map<Tour, MTour>(uow.Tours.GetOne(x => (x.TourID == id)));
        }

        public virtual bool AddTour(MTour n)
        {
            uow.Tours.Create(new Tour
            {
                NameTour = n.NameTour,
                Transport = n.Transport,
                Cost = n.Cost,
                Description = n.Description,
                HotelId = n.HotelId,
                TourID = n.TourID
            });
            uow.Save();
            return true;
        }

        public virtual bool DeleteTourByID(int id)
        {
            uow.Tours.Remove(uow.Tours.FindById(id));
            CityActions CA = new CityActions();
            CA.DeleteCitiesByID(id);
            uow.Save();
            return true;
        }


        public virtual bool ChangeTour(MTour n)
        {
            uow.Tours.Update(new Tour
            {
                NameTour = n.NameTour,
                Transport = n.Transport,
                Cost = n.Cost,
                Description = n.Description,
                HotelId = n.HotelId,
                TourID = n.TourID
            });
            uow.Save();
            return true;
        }
    }
}
