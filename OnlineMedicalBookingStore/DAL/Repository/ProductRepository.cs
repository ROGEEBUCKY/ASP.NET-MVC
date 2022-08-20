using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAL.Repository
    {
    public class ProductRepository
        {
        readonly DBContext _context;
        public ProductRepository()
            {
            _context = new DBContext();
            }

        public void AddNewProduct(Product newProduct)
            {
            try
                {
                _context.Products.AddOrUpdate(newProduct);
                _context.SaveChanges();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public Remark GetRemarkByName(string remarkName)
            {
            try
                {
                return _context.Remarks.FirstOrDefault(r => r.Name == remarkName);
                }
            catch (Exception)
                {
                throw;
                }
            }

        public List<Remark> GetRemarkList()
            {
            try
                {
                return _context.Remarks.ToList();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public List<Product> GetAllProducts()
            {
            try
                {
                return _context.Products.Include(p => p.Remark).ToList();

                }
            catch (Exception)
                {
                throw;
                }

            }

        public List<Product> GetSomeProducts(int num)
            {
            try
                {
                return _context.Products.Include(p => p.Remark).Take(num).ToList();
                }
            catch (Exception)
                {
                throw;
                }
            }



        public List<Cart> GetUserCart(int id)
            {
            try
                {
                return _context.Cart.Include(c => c.Product).Include(c => c.User).Where(c => c.UserId == id).ToList();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public List<Product> SearchForProducts(string val)
            {
            try
                {
                return _context.Products.Include(p => p.Remark).Where(p => p.Name.ToLower().Contains(val.ToLower()) || p.Remark.Name.ToLower().Contains(val.ToLower())).ToList();
                }
            catch (Exception) { throw; }
            }

        public bool CheckUserCart(int uid1, int pid2)
            {
            try
                {
                return _context.Cart.Where(c => c.UserId == uid1 && c.ProductId == pid2).Any();

                }
            catch (Exception)
                {

                throw;
                }
            }

        public Product GetProductById(int productId)
            {

            try
                {
                return _context.Products.Include(p => p.Remark).FirstOrDefault(p => p.Id == productId);
                }
            catch (Exception) { throw; }
            }

        public void AddProductToCart(Cart cartItem)
            {
            try
                {
                _context.Cart.AddOrUpdate(cartItem);
                _context.SaveChanges();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public void RemoveItemFromCart(int id)
            {
            try
                {
                var cart = _context.Cart.FirstOrDefault(c => c.Id == id);
                _context.Cart.Remove(cart);
                _context.SaveChanges();
                }
            catch (Exception)
                {

                throw;
                }
            }

        public void AddNewRemark(string val)
            {
            try
                {
                var getRemark = _context.Remarks.FirstOrDefault(r => r.Name == val);
                if (getRemark == null)
                    {
                    var remark = new Remark()
                        {
                        Name = val
                        };
                    _context.Remarks.Add(remark);
                    _context.SaveChanges();
                    }
                }
            catch (Exception)
                {

                throw;
                }
            }

        public void RemoveProduct(int id)
            {
            try
                {
                var product = _context.Products.FirstOrDefault(p => p.Id == id);
                _context.Products.Remove(product);
                _context.SaveChanges();
                }
            catch (Exception)
                {
                throw;
                }
            }

        public Cart GetCart(int id)
            {
            try
                {
                return _context.Cart.FirstOrDefault(c => c.Id == id);
                }
            catch (Exception)
                {
                throw;
                }
            }

        }
    }
