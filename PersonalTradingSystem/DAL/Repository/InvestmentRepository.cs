using DAL.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAL.Repository
    {
    public class InvestmentRepository
        {
        private readonly TradingContext _context;

        public InvestmentRepository()
            {
            _context = new TradingContext();
            }

        public void AddInvestment(Investment newInvestment)
            {
            _context.Investments.Add(newInvestment);
            _context.SaveChanges();
            }

        public List<Investment> GetInvestmentsByUser(int id)
            {
            var list = _context.Investments.Where(i => i.UserId == id && i.Status == "investment").ToList();
            return list;
            }

        public Investment GetInvestmentById(int id)
            {
            return _context.Investments.FirstOrDefault(i => i.InvestmentId == id && i.Status == "investment");
            }

        public void WithdrawInvestment(int id)
            {
            var investment = _context.Investments.FirstOrDefault(i => i.InvestmentId == id);
            investment.Status = "withdrawn";
            _context.Investments.AddOrUpdate(investment);
            _context.SaveChanges();
            }

        public List<Investment> GetWithdrawnInvestmentsByUser(int id)
            {
            var list = _context.Investments.Where(i => i.UserId == id && i.Status == "withdrawn").ToList();
            return list;
            }

        public List<Investment> GetAllInvestments()
            {
            List<Investment> list = _context.Investments.Include(u => u.User).ToList();
            return list;
            }
        }
    }
