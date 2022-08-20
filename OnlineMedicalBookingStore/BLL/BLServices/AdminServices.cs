using Common.ViewModels;
using DAL.Repository;
using System.Linq;

namespace BLL.BLServices
    {

    public class AdminServices
        {
        readonly UserRepository _userDObj;
        readonly OrderRepository _orderDObj;
        readonly ProductRepository _productDObj;
        public AdminServices()
            {
            _userDObj = new UserRepository();
            _orderDObj = new OrderRepository();
            _productDObj = new ProductRepository();
            }
        public AdminHomeVM GetInfo()
            {
            var userList = _userDObj.GetAllCustomers();
            var orderList = _orderDObj.GetAllOrderList();
            var productList = _productDObj.GetAllProducts();
            float totalSales = 0;
            foreach (var order in orderList)
                {
                totalSales += order.Amount;
                }

            AdminHomeVM info = new AdminHomeVM()
                {
                ListOfCustomers = userList.Count(),
                TotalOrdersCompleted = orderList.Count(),
                TotalProducts = productList.Count(),
                TotalSales = totalSales
                };
            return info;
            }
        }
    }
