using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.ViewModels
    {
    public class DepartmentVM
        {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<EmployeeVM> Employees { get; set; }
        }
    }
