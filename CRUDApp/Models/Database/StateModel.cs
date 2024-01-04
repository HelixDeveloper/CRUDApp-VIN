using System.ComponentModel.DataAnnotations;

namespace CRUDApp.Models.Database
{
    public class StateModel
    {
        [Key]
        public int StateId { get; set; }
        public string StateName { get; set; }

        //foreign key
    }
}
