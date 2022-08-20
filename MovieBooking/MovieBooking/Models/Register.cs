using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace MovieBooking.Models
    {
    public class Register
        {
        public static List<Customer> Customers { get; set; }



        public static void RegisterCustomer(Customer obj)
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
            list.Add(obj);
            content = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(path, content);
            }
        }

    }
    