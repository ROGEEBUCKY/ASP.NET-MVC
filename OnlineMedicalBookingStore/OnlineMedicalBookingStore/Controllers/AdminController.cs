using BLL.BLServices;
using BLL.Security;
using Common.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace OnlineMedicalBookingStore.Controllers
    {
    [CustomAuthenticationFilter]
    [CustomAuthorize("Admin")]
    public class AdminController : Controller
        {
        readonly UserServices _userBObj;
        readonly ProductServices _productBObj;
        readonly AdminServices _adminBObj;
        readonly OrderServices _orderBObj;
        public AdminController()
            {
            _orderBObj = new OrderServices();
            _userBObj = new UserServices();
            _productBObj = new ProductServices();
            _adminBObj = new AdminServices();
            }
        // Home methods
        public ActionResult Index()
            {
            try
                {
                AdminHomeVM adminInfo = _adminBObj.GetInfo();
                ViewBag.info = adminInfo;
                return View();

                }
            catch (Exception)
                {
                return Json("Something Went Wrong");
                }
            }
        public ActionResult Home()
            {
            AdminHomeVM adminInfo = _adminBObj.GetInfo();
            return PartialView("_AdminHome", adminInfo);
            }

        //Product methods
        public ActionResult Products()
            {
            return PartialView("_Products");
            }
        [HttpGet]
        public ActionResult AddNewProduct()
            {
            var remarkList = _productBObj.GetRemarkList();
            var product = new ProductVM()
                {
                RemarkList = remarkList
                };
            return PartialView("_AddNewProduct", product);
            }
        [HttpPost]
        public ActionResult AddNewProduct(ProductVM newProduct)
            {
            try
                {
                string path = Path.Combine(Server.MapPath("~/UploadedFiles"), Path.GetFileName(newProduct.ImageFile.FileName));
                newProduct.ImageFile.SaveAs(path);
                newProduct.Image = Path.Combine("/UploadedFiles", Path.GetFileName(newProduct.ImageFile.FileName));
                _productBObj.AddNewProduct(newProduct);
                }
            catch
                {
                return Json(false);
                }
            return PartialView("_Products");
            }
        [HttpGet]
        public ActionResult EditProduct(int id)
            {
            var product = _productBObj.GetAProductById(id);
            var remarkList = _productBObj.GetRemarkList();
            product.RemarkList = remarkList;
            return PartialView("_UpdateProduct", product);
            }
        [HttpPost]
        public ActionResult EditProduct(ProductVM newProduct)
            {
            try
                {
                _productBObj.AddNewProduct(newProduct);
                }
            catch (Exception e)
                {
                Console.WriteLine(e);
                }
            return PartialView("_Products");
            }

        [HttpGet]
        public ActionResult GetAllProducts()
            {
            var list = _productBObj.GetAllProducts();
            return Json(list, JsonRequestBehavior.AllowGet);

            }
        [HttpPost]
        public void AddRemark(string val)
            {
            _productBObj.AddRemark(val);
            }
        [HttpPost]
        public ActionResult DeleteProduct(int id)
            {
            try
                {
                _productBObj.RemoveProduct(id);
                }
            catch
                {
                return Json(false, JsonRequestBehavior.AllowGet);
                }
            return Json(true, JsonRequestBehavior.AllowGet);
            }


        //User Methods
        public ActionResult Users()
            {
            return PartialView("_Users");
            }
        [HttpGet]
        public ActionResult GetAllUsers()
            {
            var userList = _userBObj.GetAllUsers();
            return Json(userList, JsonRequestBehavior.AllowGet);
            }

        [HttpPost]
        public ActionResult DeleteUser(int id)
            {
            try
                {
                _userBObj.DeleteUser(id);
                }
            catch (Exception e)
                {
                Console.WriteLine(e);
                return Json(false, JsonRequestBehavior.AllowGet);
                }
            return Json(true, JsonRequestBehavior.AllowGet);
            }




        //Order Methods
        public ActionResult Orders()
            {
            return PartialView("_Orders");
            }

        [HttpGet]
        public ActionResult GetAllOrders()
            {
            var userList = _orderBObj.GetAllOrders();
            return Json(userList, JsonRequestBehavior.AllowGet);
            }

        [HttpGet]
        public ActionResult OrderDetails(int id)
            {
            var order = _orderBObj.GetOrderById(id);
            return PartialView("_OrderDetails", order);
            }
        //Message Methods
        public ActionResult Messages()
            {
            var messagedUserList = _userBObj.GetAllMessagedUser();
            if (messagedUserList.Count <= 0)
                {
                return PartialView("_Empty");
                }
            ViewBag.msgUserList = messagedUserList;
            ViewBag.userName = messagedUserList.First().Name;
            var mList = _userBObj.GetUserMessagesById(messagedUserList.First().Id);
            ViewBag.firstusermessages = mList;
            return PartialView("_AdminMessage");
            }
        [HttpGet]
        public ActionResult GetUserMessages(int id, string name)
            {
            ViewBag.userName = name;
            var mList = _userBObj.GetUserMessagesById(id);
            ViewBag.Message = mList;
            return PartialView("_UserMessages");
            }
        [HttpPost]
        public ActionResult SendMessage(MessageVM newMessage, int id, string name)
            {
            newMessage.Type = "admin";
            newMessage.UserId = id;
            _userBObj.SendNewMessage(newMessage);
            var mList = _userBObj.GetUserMessagesById(id);
            ViewBag.Message = mList;
            ViewBag.userName = name;
            return PartialView("_UserMessages");
            }
        }
    }