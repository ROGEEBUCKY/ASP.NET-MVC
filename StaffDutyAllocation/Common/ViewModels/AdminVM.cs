using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
    {
    public class AdminVM
        {
        public List<UserVM> Employees { get; set; }
        public List<UserVM> Users { get; set; }
        public List<DutyVM> Duties { get; set; }
        public List<DutyVM> AssignedDuties { get; set; }
        public List<DutyVM> UnAssignedDuties { get; set; }
        public List<RosterVM> Rosters { get; set; }
        public List <RosterVM> EmptyRosters { get; set; }
        public int Notifications { get; set; }
        public int Urequests { get; set; }
        public int Umsg { get; set; }
        }
    }
