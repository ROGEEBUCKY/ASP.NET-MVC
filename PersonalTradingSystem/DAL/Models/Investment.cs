using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
    {
    public class Investment
        {
        [Key]
        public int InvestmentId { get; set; }
        public DateTime Dated { get; set; }
        public Funds Fund { get; set; }
        [ForeignKey("Fund")]
        public int FundId { get; set; }
        public int ForPeriod { get; set; }
        public float InvestmentAmount { get; set; }
        public string Status { get; set; }
        public float FinalAmount { get; set; }
        public DateTime DateOfMaturity { get; set; }
        public User User { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        }
    }
