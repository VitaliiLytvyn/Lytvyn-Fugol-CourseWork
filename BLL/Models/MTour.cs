using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class MTour
    {
        public int TourID { get; set; }

        public string NameTour { get; set; }

        public string Description { get; set; }

        public int Cost { get; set; }

        public string Transport { get; set; }

        public int HotelId { get; set; }

        public MHotel Hotel { get; set; }

    }
}
