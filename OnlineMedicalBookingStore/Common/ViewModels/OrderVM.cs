using System;
using System.Collections.Generic;

namespace Common.ViewModels
    {
    public class OrderVM
        {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserVM User { get; set; }
        public float Amount { get; set; }
        public DateTime Created { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public List<OrderDetailsVM> OrderDetailsList { get; set; }
        }
    }
