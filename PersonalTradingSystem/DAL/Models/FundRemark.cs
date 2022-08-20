using System.ComponentModel.DataAnnotations;

namespace DAL.Models
    {
    public class FundRemark
        {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        }
    }
