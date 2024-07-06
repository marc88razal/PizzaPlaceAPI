using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PizzaPlaceAPI.DBContext;
using PizzaPlaceAPI.Models;

namespace PizzaPlaceAPI.DL
{
    public class DLPizzas
    {
        public static async Task<ServiceResponse<List<Pizzas>>> GetPizzas()
        {
            ServiceResponse<List<Pizzas>> serviceResponse;
            try
            {
                PizzaPlaceAPIContext db = new();
                var pizzas = (from o in db.pizzas select o).ToList();
                serviceResponse = new()
                {
                    Data = pizzas,
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
        public static async Task<ServiceResponse<int>> UploadCsv(List<Pizzas> pizzas)
        {
            ServiceResponse<int> serviceResponse;
            try
            {
                PizzaPlaceAPIContext db = new();
                int affectedRows;
                using (IDbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    db.AddRange(pizzas);
                    affectedRows = db.SaveChanges();
                    transaction.Commit();
                    serviceResponse = new()
                    {
                        Data = affectedRows,
                        Code = "1",
                        Status = "Success",
                        Message = string.Format(affectedRows + " affected. Pizzas CSV uploaded to pizzas table")
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
