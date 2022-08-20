using BLL.BLServices;
using BLL.Security;
using Common.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OnlineMedicalBookingStore.Controllers
    {
    [CustomAuthenticationFilter]
    [CustomAuthorize("User")]
    public class UserController : Controller
        {
        readonly UserServices _userBObj;
        readonly ProductServices _productBObj;
        readonly OrderServices _orderBObj;
        public UserController()
            {
            _userBObj = new UserServices();
            _productBObj = new ProductServices();
            _orderBObj = new OrderServices();
            }
        // GET: User
        public ActionResult Index()
            {
            var list = _productBObj.GetSomeProducts(9);
            ViewBag.products = list;
            return View();
            }
        [HttpGet]
        public ActionResult Home()
            {
            var list = _productBObj.GetSomeProducts(9);
            return PartialView("_Home", list);
            }

        [HttpPost]
        public ActionResult SearchProducts(string val)
            {
            if (string.IsNullOrEmpty(val) || string.IsNullOrWhiteSpace(val))
                {
                var plist = _productBObj.GetAllProducts();
                return PartialView("_ProductList", plist);
                }
            List<ProductVM> list = _productBObj.SearchProducts(val);
            return PartialView("_ProductList", list);
            }
     

        [HttpPost]
        public ActionResult AddToCart(int id)
            {
            UserVM user = Session["User"] as UserVM;
            ProductVM product = _productBObj.GetAProductById(id);
            bool check = _productBObj.CheckUserCart(user.Id, product.Id);
            if (check)
                {
                return Json(!check, JsonRequestBehavior.AllowGet);
                }
            else
                {
                var newItem = new CartVM()
                    {
                    UserId = user.Id,
                    ProductId = product.Id,
                    Price = product.FinalAmount,
                    };
                _productBObj.AddProductToCart(newItem);
                return Json(!check, JsonRequestBehavior.AllowGet);
                }
            }
        [HttpPost]
        public ActionResult ChangeQuantity(int id, int qty)
            {
            _productBObj.ChangeCartQtyById(id, qty);
            UserVM user = Session["User"] as UserVM;
            List<CartVM> cartList = _productBObj.GetUserCart(user.Id);
            return PartialView("_Cart", cartList);
            }
        [HttpGet]
        public ActionResult RemoveItemFromCart(int id)
            {
            _productBObj.RemoveItemFromCart(id);
            return RedirectToAction("Cart");
            }
        [HttpGet]
        public ActionResult Cart()
            {
            UserVM user = Session["User"] as UserVM;
            List<CartVM> cartList = _productBObj.GetUserCart(user.Id);
            foreach (var item in cartList)
                {
                if(item.Product.Stock <= 0)
                    {
                    _productBObj.RemoveItemFromCart(item.Id);
                    }
                }
            return PartialView("_Cart", cartList);
            }


        [HttpGet]
        public ActionResult AllProducts()
            {
            var list = _productBObj.GetAllProducts();
            return PartialView("_ProductList", list);
            }
        [HttpGet]
        public ActionResult CheckOut()
            {
            UserVM user = Session["User"] as UserVM;
            var cart = _productBObj.GetUserCart(user.Id);
            if (cart.Count() == 0)
                {
                return RedirectToAction("Home");
                }
            CheckOutVM payment = _productBObj.GetUserCheckOut(user.Id);
            return PartialView("_CheckOut", payment);
            }

        [HttpGet]
        public ActionResult PlaceOrder()
            {
            UserVM user = Session["User"] as UserVM;
            var order = _orderBObj.PlaceUserOrder(user.Id);
            return PartialView("_Bill", order);
            }
        //Message Methods
        [HttpGet]
        public ActionResult Message()
            {
            UserVM user = Session["User"] as UserVM;
            var mList = _userBObj.GetUserMessagesById(user.Id);
            ViewBag.Message = mList;
            return PartialView("_UserMessage");
            }
        [HttpPost]
        public ActionResult SendMessage(MessageVM newMessage)
            {
            _userBObj.SendNewMessage(newMessage);
            return RedirectToAction("Message");
            }




        //user profile
        [HttpGet]
        public ActionResult UserProfile()
            {
            UserVM user = Session["User"] as UserVM;
            var getUser = _userBObj.GetUserById(user.Id);
            List<OrderVM> userOrders = _orderBObj.GetUserOrders(getUser.Id);
            getUser.UserOrders = userOrders;
            return PartialView("_UserProfile", getUser);
            }
        [HttpGet]
        public ActionResult EditUser()
            {
            UserVM user = Session["User"] as UserVM;
            var getUser = _userBObj.GetUserById(user.Id);
            return PartialView("_EditUser", getUser);
            }
        [HttpPost]
        public ActionResult EditUser(UserVM user)
            {
            _userBObj.EditUser(user);
            return RedirectToAction("UserProfile");
            }
        }
    }