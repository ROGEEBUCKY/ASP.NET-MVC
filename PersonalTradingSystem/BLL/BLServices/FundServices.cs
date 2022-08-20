using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Repository;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Models;

namespace BLL.BLServices
    {
    public class FundServices
        {
        private readonly FundRepository DLO;
        public FundServices()
            {
            DLO = new FundRepository();
            }

        public List<FundsVM> GetUserFunds(int  id)
            {
            var list = DLO.GetUserFunds(id);
            return Mapper.Map<List<Funds>, List<FundsVM>>(list);
            }

        public List<FundRemarkVM> FundRemarkList()
            {
            var list = DLO.GetFundRemarks();
            return Mapper.Map<List<FundRemark>, List<FundRemarkVM>>(list);
            }

        public void AddNewFund(FundsVM fund)
            {
            var newfund = Mapper.Map<FundsVM, Funds>(fund);
            DLO.AddNewFund(newfund);
            }


        public FundsVM GetFundById(int id)
            {
            var fund = DLO.GetFundById(id);
            return Mapper.Map<Funds, FundsVM>(fund);
            }

        public List<FundsVM> GetAllFunds()
            {
            var list = DLO.GetAllFunds();

            List<FundsVM> olist = list.Select(x => new FundsVM()
                {
                FundId = x.FundId,
                Dated = x.Dated,
                FundAmount = x.FundAmount,
                FundType = x.FundRemark.Type,
                AmountUsed = x.AmountUsed,
                UserName = x.User.Name
                }).ToList();
            return olist;   
            }
         }
    }
