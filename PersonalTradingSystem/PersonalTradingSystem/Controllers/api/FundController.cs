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
    public class FundController : ApiController
    {
        public FundController()
            {
                
            }

        public IEnumerable<FundsVM> GetAllFunds()
            {
            var Bobj = new FundServices();
            var list = Bobj.GetAllFunds();
            return list;
            }
        public IEnumerable<FundsVM> GetSomeFunds(int id ,int num)
            {
            var Bobj = new FundServices();
            if(num == 100)
                {
                var flist = Bobj.GetUserFunds(id).OrderByDescending(f => f.Dated.Ticks);
                return flist;
                }
            var list = Bobj.GetUserFunds(id).OrderByDescending(f => f.Dated.Ticks).Take(num);
            return list;
            }
        }   
}
