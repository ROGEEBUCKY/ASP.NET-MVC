using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Common.ViewModels
    {
    public class FundsVM
        {
        public int? FundId { get; set; }
        public DateTime Dated { get; set; } = DateTime.Now;

        [Required]
        [Range(100, 50000, ErrorMessage = "Amount should be between 100 to 50000")]
        [DataType(DataType.Currency)]

        public float FundAmount { get; set; }
        public FundRemarkVM FundRemark { get; set; }

        [DisplayName("Fund Type")]
        [Required]
        public int FundRemarkId { get; set; }
        [DataType(DataType.Currency)]

        public float AmountUsed { get; set; } = 0;
        [Required]
        public int UserId { get; set; }
        public string FundType { get; set; }
        public string UserName { get; set; }
        public List<FundRemarkVM> FundRemarkList { get; set; } = new List<FundRemarkVM>();

        }
    }
