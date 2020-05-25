using BLL.Models;
using BLL;
using System.Collections.Generic;
using System.Web.Http;

namespace TravelAgency.Controllers
{
    public class CityController : ApiController
    {
        CityActions cityActions = new CityActions();
        // GET: api/City
        public IEnumerable<MCity> Get()
        {
            return cityActions.GetCities();
        }

        // GET: api/City/5
        public IEnumerable<MCity> Get(int id)
        {
            return cityActions.GetCitiesById(id);
        }

        // POST: api/City
        public void Post([FromBody]MCity value)
        {
            cityActions.AddCity(value);
        }

        // PUT: api/City/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/City/5
        public void Delete(int id)
        {
        }
    }
}
