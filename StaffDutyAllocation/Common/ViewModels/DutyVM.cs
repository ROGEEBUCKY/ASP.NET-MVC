using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
    {
    public class DutyVM
        {
        public int Id { get; set; }
        [Display(Name="Duty Name")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Duty Type")]
        [Required]

        public int DutyTypeId { get; set; }
        public string DutyTypeName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required]
        [Display(Name = "Duty Category")]

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<CategoryVM> Categories { get; set; } = new List<CategoryVM>();
        public List<DutyTypeVM> DutyType { get; set; }= new List<DutyTypeVM>();
        public List<UserVM> Users { get; set; } = new List<UserVM>();
        public int? UserId { get; set; }
        public string UserName { get; set; }    
        }
    }
