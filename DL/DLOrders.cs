using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PizzaPlaceAPI.DBContext;
using PizzaPlaceAPI.Models;

namespace PizzaPlaceAPI.DL
{
    public class DLOrders
    {
        public static async Task<ServiceResponse<List<Orders>>> GetOrders()
        {
            ServiceResponse<List<Orders>> serviceResponse;
            try
            {
                PizzaPlaceAPIContext db = new();
                var orders = (from o in db.orders select o).ToList();
                serviceResponse = new()
                {
                    Data = orders,
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
        public static async Task<ServiceResponse<int>> UploadCsv(List<Orders> orders)
        {
            ServiceResponse<int> serviceResponse;
            try
            {
                PizzaPlaceAPIContext db = new();
                int affectedRows;
                using (IDbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    db.AddRange(orders);
                    affectedRows = db.SaveChanges();
                    transaction.Commit();
                    serviceResponse = new()
                    {
                        Data = affectedRows,
                        Code = "1",
                        Status = "Success",
                        Message = string.Format(affectedRows + " affected. Orders CSV uploaded to orders table")
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
