using AutoMapper;
using Common.ViewModels;
using DAL.Model;
using DAL.Repository;
using System.Collections.Generic;
using System.Linq;

namespace BLL.BLServices
    {
    public class ProductServices
        {
        readonly ProductRepository _productDObj;
        public ProductServices()
            {
            _productDObj = new ProductRepository();
            }
        public void AddNewProduct(ProductVM newProduct)
            {
            var remarkId = _productDObj.GetRemarkByName(newProduct.RemarkName);
            var product = Mapper.Map<ProductVM, Product>(newProduct);
            product.RemarkId = remarkId.Id;
            _productDObj.AddNewProduct(product);
            }
        public List<ProductVM> GetSomeProducts(int v)
            {
            var pList = _productDObj.GetSomeProducts(v);
            return Mapper.Map<List<Product>, List<ProductVM>>(pList);
            }

        public List<RemarkVM> GetRemarkList()
            {
            var list = _productDObj.GetRemarkList();
            return Mapper.Map<List<Remark>, List<RemarkVM>>(list);
            }

        public List<ProductVM> GetAllProducts()
            {
            var list = _productDObj.GetAllProducts();
            return Mapper.Map<List<Product>, List<ProductVM>>(list);
            }

        public List<ProductVM> SearchProducts(string val)
            {
            var products = _productDObj.SearchForProducts(val);
            return Mapper.Map<List<Product>, List<ProductVM>>(products);
            }

        public bool CheckUserCart(int uid1, int pid2)
            {
            return _productDObj.CheckUserCart(uid1, pid2);
            }

        public ProductVM GetAProductById(int id)
            {
            var product = _productDObj.GetProductById(id);
            return Mapper.Map<Product, ProductVM>(product);
            }

        public void AddProductToCart(CartVM newItem)
            {
            var cartItem = Mapper.Map<CartVM, Cart>(newItem);
            _productDObj.AddProductToCart(cartItem);
            }

        public void RemoveItemFromCart(int id)
            {
            _productDObj.RemoveItemFromCart(id);
            }

        public List<CartVM> GetUserCart(int id)
            {
            List<Cart> cartList = _productDObj.GetUserCart(id);
            return Mapper.Map<List<Cart>, List<CartVM>>(cartList);
            }

        public void ChangeCartQtyById(int id, int qty)
            {
            Cart cart = _productDObj.GetCart(id);
            cart.Quantity = qty;
            _productDObj.AddProductToCart(cart);
            }


        public CheckOutVM GetUserCheckOut(int id)
            {
            var cartList = GetUserCart(id);
            float? amount = 0;
            foreach (var item in cartList)
                {
                amount += item.Price * item.Quantity;
                }
            var payment = new CheckOutVM()
                {
                TotalAmount = amount,
                NumberOfItems = cartList.Count()
                };
            return payment;
            }

        public void AddRemark(string val)
            {
            _productDObj.AddNewRemark(val);
            }

        public void RemoveProduct(int id)
            {
            _productDObj.RemoveProduct(id);
            }
        }
    }
