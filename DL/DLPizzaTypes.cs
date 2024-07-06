using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PizzaPlaceAPI.DBContext;
using PizzaPlaceAPI.Models;

namespace PizzaPlaceAPI.DL
{
    public class DLPizzaTypes
    {
        public static async Task<ServiceResponse<List<PizzaTypes>>> GetPizzaTypes()
        {
            ServiceResponse<List<PizzaTypes>> serviceResponse;
            try
            {
                PizzaPlaceAPIContext db = new();
                var pizzaTypes = (from o in db.pizza_types select o).ToList();
                serviceResponse = new()
                {
                    Data = pizzaTypes,
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
        public static async Task<ServiceResponse<int>> UploadCsv(List<PizzaTypes> pizzaTypes)
        {
            ServiceResponse<int> serviceResponse;
            try
            {
                PizzaPlaceAPIContext db = new();
                int affectedRows;
                using (IDbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    db.AddRange(pizzaTypes);
                    affectedRows = db.SaveChanges();
                    transaction.Commit();
                    serviceResponse = new()
                    {
                        Data = affectedRows,
                        Code = "1",
                        Status = "Success",
                        Message = string.Format(affectedRows + " affected. Pizza Types CSV uploaded to pizza_types table")
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
