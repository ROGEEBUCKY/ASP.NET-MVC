using DAL.Models;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using System.Linq;
using System;

namespace DAL.Repository
    {
    public class DutyRepository
        {
        readonly AppDBContext _dbContext;
        public DutyRepository()
            {
            _dbContext = new AppDBContext();
            }

        public void AddNewDutyD(Duty newDuty)
            {
            _dbContext.Duty.AddOrUpdate(newDuty);
            _dbContext.SaveChanges();
            }

        public List<Duty> GetAllDutiesD()
            {
            var list = _dbContext.Duty.Include(d => d.Category).Include(d => d.Type).ToList();
            return list;
            }

        public List<Duty> GetAllUnAllocatedDutiesD()
            {
            var alllist = _dbContext.Duty.ToList();
            var assignedduty = _dbContext.AssignedDuties.ToList();
            List<Duty> duties = (from x in alllist
                          join y in assignedduty on x.Id equals y.DutyId
                          select x).ToList();
            return alllist.Except(duties).ToList();
            }
        public void AssignDuty(AssignedDuties duty)
            {
            _dbContext.AssignedDuties.AddOrUpdate(duty);
            _dbContext.SaveChanges();
            }
        public int GetRosterAssignedDuties(int id)
            {
            var num = _dbContext.AssignedDuties.Where(ad => ad.RosterId == id).Count();
            return num;
            }
        public List<AssignedDuties> GetAssignedDutieslist()
            {
            var list = _dbContext.AssignedDuties.ToList();
            return list;
            }
        public List<Category> GetAllCategoriesD()
            {
            return _dbContext.Categories.ToList();
            }
        public List<DutyType> GetAllDutyTypes()
            {
            return _dbContext.DutyTypes.ToList();
            }
        public List<AssignedDuties> GetAllAssignedDuties()
            {
            return _dbContext.AssignedDuties.Include(a => a.User).ToList();
            }

        public void UnAssignDuty(int id)
            {
            var aduty = GetAllAssignedDuties().FirstOrDefault(d => d.Id == id);
            _dbContext.AssignedDuties.Remove(aduty);
            _dbContext.SaveChanges();
            }
        }
    }
