using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Common.ViewModels
    {
    public class InvestmentVM
        {
        public int? InvestmentId { get; set; }
        [DisplayName("Current Date")]
        public DateTime Dated { get; set; } = DateTime.Now;
        [DisplayName("Fund ID")]
        public int FundId { get; set; }
        [Required]
        [Range(3, 36, ErrorMessage = "Please input months from 3 to 36")]
        [DisplayName("For Period in months")]
        public int ForPeriod { get; set; }
        [Required]
        [DisplayName("Investment Amount")]
        [DataType(DataType.Currency)]
        public float InvestmentAmount { get; set; }
        public string Status { get; set; } = "investment";

        [DisplayName("Final Amount After Maturity")]
        [DataType(DataType.Currency)]

        public float FinalAmount { get; set; }

        [DisplayName("Maturity Date")]
        public DateTime DateOfMaturity { get; set; }

        [Required]
        public int UserId { get; set; }
        public string UserName { get; set; }
        }
    }
