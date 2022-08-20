using AutoMapper;
using Common.ViewModels;
using DAL.Model;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.BLServices
    {
    public class OrderServices
        {
        readonly OrderRepository _orderDObj;
        readonly UserRepository _userDObj;
        readonly ProductRepository _productDObj;
        public OrderServices()
            {
            _orderDObj = new OrderRepository();
            _userDObj = new UserRepository();
            _productDObj = new ProductRepository();
            }

        public OrderVM PlaceUserOrder(int id)
            {
            User user = _userDObj.GetUserByID(id);
            List<Cart> cartList = _productDObj.GetUserCart(user.Id);
            float amount = 0;
            foreach (var item in cartList)
                {
                amount += item.Price * item.Quantity;
                }

            Orders newOrder = new Orders()
                {
                UserId = user.Id,
                Amount = amount,
                Created = DateTime.Now,
                Address = user.Address,
                City = user.City,
                State = user.State,
                ZipCode = user.Zip
                };
            _orderDObj.PlaceUserOrder(newOrder);

            foreach (Cart cart in cartList)
                {
                OrderDetails oDetails = new OrderDetails()
                    {
                    OrderId = newOrder.Id,
                    Price = cart.Price,
                    Quantity = cart.Quantity,
                    ProductId = cart.ProductId
                    };
                _orderDObj.AddOrderDetails(oDetails);
                _productDObj.RemoveItemFromCart(cart.Id);
                Product product = _productDObj.GetProductById(cart.ProductId);
                product.Stock -= cart.Quantity;
                _productDObj.AddNewProduct(product);
                }
            List<OrderDetails> orderDetails = _orderDObj.GetOrderDetailsByOrderId(newOrder.Id);
            var orderVm = Mapper.Map<Orders, OrderVM>(newOrder);
            orderVm.OrderDetailsList = Mapper.Map<List<OrderDetails>, List<OrderDetailsVM>>(orderDetails);
            return orderVm;
            }

        public List<OrderVM> GetAllOrders()
            {
            var orders = _orderDObj.GetAllOrderList();
            List<OrderVM> vmOrders = orders.Select(o => new OrderVM()
                {
                Id = o.Id,
                UserId = o.UserId,
                Address = o.Address,
                City = o.City,
                Amount = o.Amount,
                Created = o.Created,
                ZipCode = o.ZipCode,
                State = o.State,
                OrderDetailsList = GetOrderDetailsByOrderId(o.Id)
                }).ToList();
            return vmOrders;
            }
        public List<OrderDetailsVM> GetOrderDetailsByOrderId(int id)
            {
            var list = _orderDObj.GetOrderDetailsByOrderId(id).ToList();
            return Mapper.Map<List<OrderDetails>, List<OrderDetailsVM>>(list);
            }

        public List<OrderVM> GetUserOrders(int id)
            {
            List<Orders> userOrders = _orderDObj.GetUserOrders(id);
            var VMOrders = Mapper.Map<List<Orders>, List<OrderVM>>(userOrders);
            foreach (var order in VMOrders)
                {
                order.OrderDetailsList = GetOrderDetailsByOrderId(order.Id);
                }
            return VMOrders;
            }

        public OrderVM GetOrderById(int id)
            {
            Orders order = _orderDObj.GetOrderById(id);
            var vMOrder = Mapper.Map<Orders, OrderVM>(order);
            vMOrder.OrderDetailsList = GetOrderDetailsByOrderId(order.Id);
            return vMOrder;
            }
        }
    }
