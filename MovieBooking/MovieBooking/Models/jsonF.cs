using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using MovieBooking.Models;
using System.Configuration;

namespace MovieBooking.Models
    {
    public class JsonF 
        {
        public List<string> genres = new List<string>();
        public List<Movie> movies = new List<Movie>();


        public  JsonF GetJson()
            {
            var path = ConfigurationManager.AppSettings["MoviePath"];
            //var path = @"D:\ASP.NET MVC\MovieBooking\MovieBooking\App_Data\Movies.json";
            var content = File.ReadAllText(path);
            if (String.IsNullOrEmpty(content))
                {
                return null;
                }
            else
                {
                JsonF jObj = JsonConvert.DeserializeObject<JsonF>(content);
                return jObj;
                }
            }

     
        }
    }