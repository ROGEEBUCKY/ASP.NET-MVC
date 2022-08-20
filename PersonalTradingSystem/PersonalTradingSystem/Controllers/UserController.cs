using BLL.BLServices;
using Common.ViewModels;
using System.Web.Mvc;

namespace PersonalTradingSystem.Controllers
    {
    public class UserController : Controller
        {
        private readonly FundServices BLO;
        private readonly InvestmentServices InvestBLO;
        public UserController()
            {
            BLO = new FundServices();
            InvestBLO = new InvestmentServices();
            }
        // GET: User
        public ActionResult Index()
            {
            if (Session["User"] == null)
                {
                return RedirectToAction("Index", "Login");

                }
            else
                {
                UserVM u = Session["User"] as UserVM;
                if (u.RoleId == 3)
                    return View();
                else
                    return RedirectToAction("Index", "Admin");
                }
            }
        public ActionResult Funds()
            {
            if (Session["User"] != null)
                {
                return View();
                }
            else
                {
                return RedirectToAction("Index", "Login");
                }
            }
        [HttpPost]
        public ActionResult GetFunds()
            {
            var user = Session["User"] as UserVM;
            var relist = BLO.FundRemarkList();
            var uId = user.Id;
            var list = BLO.GetUserFunds(uId);
            foreach (var item in list)
                {
                foreach (var ritem in relist)
                    {
                    if (item.FundRemarkId == ritem.Id)
                        {
                        item.FundType = ritem.Type;
                        }
                    }
                }
            return Json(new { id = "1", data = list }, JsonRequestBehavior.AllowGet);
            }

        [HttpPost]
        public ActionResult GetAFund(int id)
            {
            var fund = BLO.GetFundById(id);

            var relist = BLO.FundRemarkList();

            foreach (var ritem in relist)
                {
                if (ritem.Id == fund.FundRemarkId)
                    {
                    fund.FundType = ritem.Type;
                    }
                }

            return Json(new { data = fund }, JsonRequestBehavior.AllowGet);
            }

        public ActionResult AddFunds()
            {

            if (Session["User"] != null)
                {
                var remarkList = BLO.FundRemarkList();
                var fund = new FundsVM()
                    {
                    FundRemarkList = remarkList
                    };
                return View(fund);
                }
            else
                {
                return RedirectToAction("Index", "Login");
                }

            }

        [HttpPost]
        public ActionResult AddFunds(FundsVM fund)
            {
            if (!ModelState.IsValid)
                {
                return View(fund);
                }
            else
                {
                BLO.AddNewFund(fund);
                return RedirectToAction("Funds");
                }
            }

        public ActionResult Investments()
            {
            if (Session["User"] != null)
                {
                return View();
                }
            else
                {
                return RedirectToAction("Index", "Login");
                }
            }

        [HttpPost]
        public ActionResult GetInvestments()
            {
            var user = Session["User"] as UserVM;
            var list = InvestBLO.GetInvestmentByUser(user.Id);
            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
            }

        public ActionResult AddInvestment()
            {
            if (Session["User"] != null)
                {
                return View();
                }
            else
                {
                return RedirectToAction("Index", "Login");
                }
            }
        [HttpPost]
        public ActionResult AddInvestment(InvestmentVM newInvestment)
            {
            if (!ModelState.IsValid)
                {
                return View("AddInvestment", newInvestment);
                }
            else
                {
                InvestBLO.AddNewInvestment(newInvestment);
                ViewBag.message = "Investment Added Successfully";
                return View();
                }
            }
        [HttpPost]
        public void WithdrawInvestment( int id)
            {
            InvestBLO.WithdrawInvestment(id);
            }

        public ActionResult UserHistory()
            {
            if (Session["User"] != null)
                {
                return View();
                }
            else
                {
                return RedirectToAction("Index", "Login");
                }
            }
        [HttpPost]
        public ActionResult GetUserWithdrawnInvestments()
            {
            var user = Session["User"] as UserVM;
            var list = InvestBLO.GetWithdrawnInvestmentByUser(user.Id);
            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
            }
        }
    }
