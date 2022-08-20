using AutoMapper;
using Common.ViewModels;
using DAL.Models;
using DAL.Repository;
using System.Collections.Generic;
using System.Linq;

namespace BLL.BLServices
    {
    public class InvestmentServices
        {
        private readonly InvestmentRepository DoBj;
        private readonly FundRepository FObj;

        public InvestmentServices()
            {
            FObj = new FundRepository();
            DoBj = new InvestmentRepository();
            }
        public void AddNewInvestment(InvestmentVM newInvestment)
            {
            var id = newInvestment.FundId;
            var fund = FObj.GetFundById(id);
            fund.AmountUsed += newInvestment.InvestmentAmount;
            fund.FundAmount -= newInvestment.InvestmentAmount;
            FObj.AddNewFund(fund);
            var invest = Mapper.Map<InvestmentVM, Investment>(newInvestment);
            DoBj.AddInvestment(invest);
            }

        public List<InvestmentVM> GetInvestmentByUser(int id)
            {
            var list = DoBj.GetInvestmentsByUser(id);
            return Mapper.Map<List<Investment>, List<InvestmentVM>>(list);
            }
        public List<InvestmentVM> GetWithdrawnInvestmentByUser(int id)
            {
            var list = DoBj.GetWithdrawnInvestmentsByUser(id);
            return Mapper.Map<List<Investment>, List<InvestmentVM>>(list);
            }

        public void WithdrawInvestment(int id)
            {
            Investment investment = DoBj.GetInvestmentById(id);
            var fundid = investment.FundId;
            var fund = FObj.GetFundById(fundid);
            fund.FundAmount += investment.FinalAmount;
            FObj.AddNewFund(fund);
            DoBj.WithdrawInvestment(id);
            }

        public List<InvestmentVM> GetAllInvestments()
            {
            var list = DoBj.GetAllInvestments();
            List<InvestmentVM> a = list.Select(x => new InvestmentVM()
                {
                InvestmentId = x.InvestmentId,
                Dated = x.Dated,
                FundId = x.FundId,
                DateOfMaturity = x.DateOfMaturity,
                InvestmentAmount = x.InvestmentAmount,
                FinalAmount = x.FinalAmount,
                UserName = x.User.Name,
                Status = x.Status
                }).ToList();
            return a;
            }
        }
    }
