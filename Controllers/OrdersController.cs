using Microsoft.AspNetCore.Mvc;
using PizzaPlaceAPI.DBContext;
using PizzaPlaceAPI.Models;
using PizzaPlaceAPI.DL;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PizzaPlaceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
      
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload(List<Orders> orders)
        {
            ServiceResponse<int> serviceResponse = new ServiceResponse<int>();
            serviceResponse = await DLOrders.UploadCsv(orders);
            return StatusCode(serviceResponse.Code == "1" ? 200 : 500, serviceResponse.Message);
            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ServiceResponse<List<Orders>> serviceResponse = new ServiceResponse<List<Orders>>();
            serviceResponse = await DLOrders.GetOrders();
            return StatusCode(serviceResponse.Code == "1" ? 200 : 500, serviceResponse.Data);

        }
    }
}
