using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model
    {
    public class Orders
        {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public float Amount { get; set; }
        public DateTime Created { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        }
    }
