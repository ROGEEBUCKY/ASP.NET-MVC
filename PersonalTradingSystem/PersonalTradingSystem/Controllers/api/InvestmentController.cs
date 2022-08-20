using BLL.BLServices;
using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PersonalTradingSystem.Controllers.api
{
    public class InvestmentController : ApiController
    {
        public IEnumerable<InvestmentVM> GetAllInvestments()
            {
            var Bobj = new InvestmentServices();
            var list = Bobj.GetAllInvestments();
            return list;
            }

        public IEnumerable<InvestmentVM> GetSomeInvestments(int id, int num)
            {
            var Bobj = new InvestmentServices();
            if (num == 100)
                {
                var flist = Bobj.GetInvestmentByUser(id).OrderByDescending(f => f.Dated.Ticks);
                return flist;
                }
            var list = Bobj.GetInvestmentByUser(id).OrderByDescending(f => f.Dated.Ticks).Take(num);
            return list;
            }
        }
}
