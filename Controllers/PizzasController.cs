using Microsoft.AspNetCore.Mvc;
using PizzaPlaceAPI.DBContext;
using PizzaPlaceAPI.Models;
using PizzaPlaceAPI.DL;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PizzaPlaceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzasController : ControllerBase
    {
      
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload(List<Pizzas> pizzas)
        {
            ServiceResponse<int> serviceResponse = new ServiceResponse<int>();
            serviceResponse = await DLPizzas.UploadCsv(pizzas);
            return StatusCode(serviceResponse.Code == "1" ? 200 : 500, serviceResponse.Message);
            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ServiceResponse<List<Pizzas>> serviceResponse = new ServiceResponse<List<Pizzas>>();
            serviceResponse = await DLPizzas.GetPizzas();
            return StatusCode(serviceResponse.Code == "1" ? 200 : 500, serviceResponse.Data);

        }
    }
}
