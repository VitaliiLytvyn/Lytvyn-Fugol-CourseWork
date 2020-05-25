using BLL;
using BLL.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace TravelAgency.Controllers
{
    public class ToursController : ApiController
    {
        TourActions tourActions = new TourActions();
        // GET: api/Tours
        public IEnumerable<MTour> Get()
        {
            return tourActions.GetTours() ;
        }

        // GET: api/Tours/5
        public MTour Get(int id)
        {
            return tourActions.GetTourById(id);
        }

        // POST: api/Tours
        [HttpPost]
        public void Post([FromBody]MTour value)
        {
            tourActions.AddTour(value);
        }

        // PUT: api/Tours/5
        [HttpPut]
        public void Put(int id, [FromBody]MTour value)
        {
            tourActions.ChangeTour(value);
        }

        // DELETE: api/Tours/5
        public void Delete(int id)
        {
            tourActions.DeleteTourByID(id);
        }
    }
}
