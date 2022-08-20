using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Movies.Models
    {
    public class JsonFile
        {
        public List<string> genres = new List<string>();
        public List<object> movies = new List<object>();


        public JsonFile GetJson()
            {
            var path = @"D:\ASP.NET MVC\Movies\Movies\App_Data\Movies.json";
            var content = File.ReadAllText(path);
            if (String.IsNullOrEmpty(content))
                {
                return null;
                }
            else
                {
                JsonFile jObj = JsonConvert.DeserializeObject<JsonFile>(content);
                return jObj;
                }
            }


        }
    }