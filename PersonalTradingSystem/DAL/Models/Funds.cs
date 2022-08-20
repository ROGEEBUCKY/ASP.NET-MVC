using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
    {
    public class Funds
        {
        [Key]
        public int FundId { get; set; }
        public DateTime Dated { get; set; }
        
        public float FundAmount { get; set; }
        public FundRemark FundRemark { get; set; }

        [ForeignKey("FundRemark")]
        public int FundRemarkId { get; set; }
        public float AmountUsed { get; set; }
        public User User { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

        }
    }
