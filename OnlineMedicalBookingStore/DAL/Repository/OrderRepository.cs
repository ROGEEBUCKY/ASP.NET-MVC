using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repository
    {
    public class OrderRepository
        {
        readonly DBContext _context;
        public OrderRepository()
            {
            _context = new DBContext();
            }

        public List<Orders> GetAllOrderList()
            {
            try
                {
                return _context.Orders.ToList();
                }
            catch (Exception)
                {
                throw;
                }
            }
        public Orders PlaceUserOrder(Orders newOrder)
            {
            try
                {
                _context.Orders.Add(newOrder);
                _context.SaveChanges();
                return newOrder;

                }
            catch (Exception)
                {

                throw;
                }
            }

        public void AddOrderDetails(OrderDetails oDetails)
            {
            try
                {
                _context.OrderDetails.Add(oDetails);
                _context.SaveChanges();

                }
            catch (Exception)
                {

                throw;
                }
            }

        public List<OrderDetails> GetOrderDetailsByOrderId(int id)
            {
            try
                {
                return _context.OrderDetails.Include(o => o.Product).Where(o => o.OrderId == id).ToList();

                }
            catch (Exception)
                {

                throw;
                }
            }

        public List<Orders> GetUserOrders(int id)
            {
            try
                {
                return _context.Orders.Where(o => o.UserId == id).ToList();

                }
            catch (Exception)
                {

                throw;
                }
            }

        public Orders GetOrderById(int id)
            {
            try
                {
                return _context.Orders.FirstOrDefault(o => o.Id == id);

                }
            catch (Exception)
                {

                throw;
                }
            }

        }
    }
