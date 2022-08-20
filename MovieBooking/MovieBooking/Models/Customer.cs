using Microsoft.Web.Mvc.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace MovieBooking.Models
    {
    public class Customer
        {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false,ErrorMessage ="Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }


        public string Password { get; set; }



        public static List<Customer> GetCustomers()
            {
            List<Customer> list;
            var path = ConfigurationManager.AppSettings["CustomerPath"];
            var content = File.ReadAllText(path);
            if (content == "")
                {
                list = new List<Customer>();
                }
            else
                {
                list = JsonConvert.DeserializeObject<List<Customer>>(content);
                }
            content = JsonConvert.SerializeObject(list, Formatting.Indented);
            return list;
            }
        public static int GenerateID()
            {
            var list = Customer.GetCustomers();
            if(list.Count == 0)
                {
                return 0;
                }
            else
                {
                return list.Max(x => x.Id);
                }
            }
        }
    }