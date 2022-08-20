using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Common.ViewModels
    {
    public class RosterVM
        {
        public int Id { get; set; }
        [Required]
        [Remote("RosterAlreadyExist", "Admin", ErrorMessage = "Roster Already Exist", HttpMethod = "POST")]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int NumberOfDuties { get; set; }
        public List<DutyVM> ListOfDuties { get; set; } = new List<DutyVM>();
        [Display(Name="Select Duties")]
        public int[] SelectedDutyId { get; set; }
        public List<UserVM> UnAssignedUsers { get; set; } = new List<UserVM>(); 
        }
    }
