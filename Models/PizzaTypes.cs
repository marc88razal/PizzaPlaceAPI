using System.ComponentModel;

namespace PizzaPlaceAPI.Models
{
    public class PizzaTypes
    {
        [DisplayName("Pizza Type Id")]
        public string pizza_type_id {  get; set; }

        [DisplayName("Name")]
        public string name { get; set; }

        [DisplayName("Category")]
        public string category { get; set; }

        [DisplayName("Ingredients")]
        public string ingredients {  get; set; }
    }
}
