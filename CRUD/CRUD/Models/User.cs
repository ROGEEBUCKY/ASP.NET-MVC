using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models
    {
    public class User
        {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        [DataType(DataType.Currency)]
        public float Salary { get; set; }
        public string IsActive { get; set; } = "active";
        }
    }