using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDApp.Models.Database
{
    [Table("tblCountry")]
    public class CountryModel
    {
        [Key]
        public int CountryId { get; set; }
        [Required]
        public string CountryName { get; set; }
        public string CountryCode { get; set; }

        //this code for state

    }
}
