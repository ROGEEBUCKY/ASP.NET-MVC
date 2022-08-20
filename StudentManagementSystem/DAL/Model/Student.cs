using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
    {
    public class Student
        {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Section Section { get; set; }

        [ForeignKey("Section")]
        public int SectionId { get; set; }
        public string Address { get; set; }
        }
    }
