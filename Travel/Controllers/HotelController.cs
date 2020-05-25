using BLL;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Travel.Controllers
{
    public class HotelController : ApiController
    {
        HotelActions hotelActions = new HotelActions();
        // GET: api/Hotel
        public IEnumerable<MHotel> Get()
        {
            return hotelActions.GetHotels();
        }

        // GET: api/Hotel/5
        public MHotel Get(int id)
        {
            return hotelActions.GetHotelyId(id);
        }

        // POST: api/Hotel
        public void Post([FromBody]MHotel value)
        {
            hotelActions.AddHotel(value);
        }

        // PUT: api/Hotel/5
        public void Put(int id, [FromBody]MHotel value)
        {
            hotelActions.ChangeHotel(value);
        }

        // DELETE: api/Hotel/5
        public void Delete(int id)
        {
            hotelActions.DeleteHotelByID(id);
        }
    }
}
