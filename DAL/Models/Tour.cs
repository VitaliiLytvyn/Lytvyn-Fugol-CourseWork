using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Tour
    {
        [Key]
        public int TourID { get; set; }

        public string NameTour { get; set; }

        public string Description { get; set; }

        public int Cost { get; set; }

        public string Transport { get; set; }

        public int HotelId { get; set; }

        [ForeignKey("HotelId")]
        public Hotel Hotel { get; set; }
    }
}
