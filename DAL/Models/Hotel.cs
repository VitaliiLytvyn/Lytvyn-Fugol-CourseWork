using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }

        public string Name { get; set; }

        public byte Stars { get; set; }
        
        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }
    }
}
