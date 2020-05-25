using AutoMapper;
using BLL.Models;
using DAL;
using DAL.Models;
using System.Collections.Generic;

namespace BLL
{
    public class HotelActions
    {
        IMapper TourM = new MapperConfiguration(cfg => cfg.CreateMap<Hotel, MHotel>().
        ForMember(x => x.City, y => y.MapFrom(c => c.City))).CreateMapper();

        private readonly UnitOfWork uow;

        public HotelActions(UnitOfWork uow)
        {
            this.uow = uow;
        }

        public HotelActions()
        {
            Context context = new Context();
            uow = new UnitOfWork(context, 
                new ContextRepository<User>(context), new ContextRepository<Tour>(context), new ContextRepository<City>(context), new ContextRepository<Hotel>(context));
        }


        public virtual List<MHotel> GetHotels()
        {
            return TourM.Map<IEnumerable<Hotel>, List<MHotel>>(uow.Hotels.Get());
        }

        public virtual MHotel GetHotelyId(int id)
        {
            return TourM.Map<Hotel, MHotel>(uow.Hotels.GetOne(x => (x.HotelId == id)));
        }

        public virtual bool AddHotel(MHotel n)
        {
            uow.Hotels.Create(new Hotel
            {
                Name = n.Name,
                Stars = n.Stars,
                CityId = n.CityId
            });
            uow.Save();
            return true;
        }

        public virtual bool DeleteHotelByID(int id)
        {
            uow.Hotels.Remove(uow.Hotels.FindById(id));
            uow.Save();
            return true;
        }

        public virtual bool ChangeHotel(MHotel n)
        {
            uow.Hotels.Update(new Hotel
            {
                Name = n.Name,
                Stars = n.Stars,
                CityId = n.CityId,
                HotelId = n.HotelId
            });
            uow.Save();
            return true;
        }
    }
}
