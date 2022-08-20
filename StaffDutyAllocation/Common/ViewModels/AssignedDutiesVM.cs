using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
    {
    public class AssignedDutiesVM
        {
        public int Id { get; set; }
        public int DutyId { get; set; }
        public int? UserId { get; set; }
        public int RosterId { get; set; }
        public DateTime AssignedTime { get; set; }
        }
    }
