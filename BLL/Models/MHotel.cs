namespace BLL.Models
{
    public class MHotel
    {
        public int HotelId { get; set; }

        public string Name { get; set; }

        public byte Stars { get; set; }

        public int CityId { get; set; }

        public MCity City { get; set; }

    }
}
