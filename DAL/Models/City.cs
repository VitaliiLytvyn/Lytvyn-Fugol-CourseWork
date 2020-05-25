using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class City
    {
        [Key]
        public int CityID { get; set; }

        public string NameCity { get; set; }

        public string NameCountry { get; set; }
    }
}
