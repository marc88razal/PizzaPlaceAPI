using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PizzaPlaceAPI.DBContext;
using PizzaPlaceAPI.Models;

namespace PizzaPlaceAPI.DL
{
    public class DLOrderDetails
    {
        public static async Task<ServiceResponse<List<OrderDetails>>> GetOrderDetails()
        {
            ServiceResponse<List<OrderDetails>> serviceResponse;
            try
            {
                PizzaPlaceAPIContext db = new();
                var orderDetails = (from o in db.order_details select o).ToList();
                serviceResponse = new()
                {
                    Data = orderDetails,
                    Code = "1",
                    Status = "Success",
                    Message = string.Format("Records Retrieved")
                };
            }
            catch (Exception ex)
            {
                serviceResponse = new()
                {
                    Data = null,
                    Code = "0",
                    Status = "Failed",
                    Message = string.Format("{0}-{1}", ex.Message, ex.StackTrace.ToString())
                };
            }
            return serviceResponse;
        }
        public static async Task<ServiceResponse<int>> UploadCsv(List<OrderDetails> orderDetails)
        {
            ServiceResponse<int> serviceResponse;
            try
            {
                PizzaPlaceAPIContext db = new();
                int affectedRows;
                using (IDbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    db.AddRange(orderDetails);
                    affectedRows = db.SaveChanges();
                    transaction.Commit();
                    serviceResponse = new()
                    {
                        Data = affectedRows,
                        Code = "1",
                        Status = "Success",
                        Message = string.Format(affectedRows + " affected. Order Details CSV uploaded to order_details table")
                    };
                }

            }
            catch (Exception ex)
            {
                serviceResponse = new()
                {
                    Data = 0,
                    Code = "0",
                    Status = "Failed",
                    Message = string.Format("{0}-{1}", ex.Message, ex.InnerException.Message.ToString())
                };
            }

            return serviceResponse;
        }
    }
}
