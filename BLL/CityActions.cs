using AutoMapper;
using BLL.Models;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CityActions
    {
        IMapper CityM;
        private readonly UnitOfWork uow;
        public CityActions(UnitOfWork uow)
        {
            this.uow = uow;
        }

        public CityActions()
        {
            CityM = new MapperConfiguration(cfg => cfg.CreateMap<City, MCity>()).CreateMapper();
            Context context = new Context();
            uow = new UnitOfWork(context, new ContextRepository<User>(context),
                new ContextRepository<Tour>(context), new ContextRepository<City>(context), new ContextRepository<Hotel>(context));
        }


        public virtual List<MCity> GetCities()
        {
            return CityM.Map<IEnumerable<City>, List<MCity>>(uow.Cities.Get());
        }

        public virtual List<MCity> GetCitiesById(int id)
        {
            return CityM.Map<IEnumerable<City>, List<MCity>>(uow.Cities.Get().Where(x => x.CityID == id)); ;
        }

        public virtual void AddCity(MCity mCity)
        {
            uow.Cities.Create(new City
            {
                NameCity = mCity.NameCity,
                NameCountry = mCity.NameCountry
            });
            uow.Save();
        }

        public virtual bool DeleteCitiesByID(int id)
        {
            uow.Cities.Remove(uow.Cities.FindById(id));
            uow.Save();
            return true;
        }
    }
}
