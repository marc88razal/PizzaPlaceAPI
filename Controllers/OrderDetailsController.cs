using Microsoft.AspNetCore.Mvc;
using PizzaPlaceAPI.DBContext;
using PizzaPlaceAPI.Models;
using PizzaPlaceAPI.DL;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PizzaPlaceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderDetailsController : ControllerBase
    {
      
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload(List<OrderDetails> orderDetails)
        {
            ServiceResponse<int> serviceResponse = new ServiceResponse<int>();
            serviceResponse = await DLOrderDetails.UploadCsv(orderDetails);
            return StatusCode(serviceResponse.Code == "1" ? 200 : 500, serviceResponse.Message);
            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ServiceResponse<List<OrderDetails>> serviceResponse = new ServiceResponse<List<OrderDetails>>();
            serviceResponse = await DLOrderDetails.GetOrderDetails();
            return StatusCode(serviceResponse.Code == "1" ? 200 : 500, serviceResponse.Data);

        }
    }
}
