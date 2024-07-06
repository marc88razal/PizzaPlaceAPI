using Microsoft.AspNetCore.Mvc;
using PizzaPlaceAPI.DBContext;
using PizzaPlaceAPI.Models;
using PizzaPlaceAPI.DL;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PizzaPlaceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaTypesController : ControllerBase
    {
      
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload(List<PizzaTypes> pizzaTypes)
        {
            ServiceResponse<int> serviceResponse = new ServiceResponse<int>();
            serviceResponse = await DLPizzaTypes.UploadCsv(pizzaTypes);
            return StatusCode(serviceResponse.Code == "1" ? 200 : 500, serviceResponse.Message);
            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ServiceResponse<List<PizzaTypes>> serviceResponse = new ServiceResponse<List<PizzaTypes>>();
            serviceResponse = await DLPizzaTypes.GetPizzaTypes();
            return StatusCode(serviceResponse.Code == "1" ? 200 : 500, serviceResponse.Data);

        }
    }
}
