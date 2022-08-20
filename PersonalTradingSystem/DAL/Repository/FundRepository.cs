using DAL.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAL.Repository
    {
    public class FundRepository
        {
        private readonly TradingContext _Context;
        public FundRepository()
            {
            _Context = new TradingContext();
            }


        public void AddNewFund(Funds fund)
            {
            _Context.Funds.AddOrUpdate(fund);
            _Context.SaveChanges();
            }
        public List<Funds> GetUserFunds(int id)
            {
            var list = _Context.Funds.Where(f => f.UserId == id).ToList();
            return list;
            }

        public List<FundRemark> GetFundRemarks()
            {
            var list = _Context.FundRemarks.ToList();
            return list;
            }

        public Funds GetFundById(int id)
            {
            var fund = _Context.Funds.FirstOrDefault(f => f.FundId == id);
            return fund;
            }

        public List<Funds> GetAllFunds()
            {
            var list = _Context.Funds.Include(f => f.FundRemark).Include(f => f.User).ToList();
            return list;
            }
        }
    }
