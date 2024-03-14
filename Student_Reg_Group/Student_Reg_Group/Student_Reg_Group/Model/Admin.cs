using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Reg_Group.ViewModel;

namespace Student_Reg_Group.Model
{
    public class Admin
    {
       
        public string AdminUsername { get; set; }
        public int AdminPassword { get; set; }
        public int AdminId { get; set; }
        public UserType UserType { get; set; }
    }

    /*
    public enum UserType
    {
        Admin,
        Normal
    }
    */
}
