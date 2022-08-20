using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
    {
    public class Duty
        {
        public int Id { get; set; }
        public string Name { get; set; }
        public DutyType Type { get; set; }
        [ForeignKey("Type")]
        public int DutyTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Category Category { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        
        }
    }
