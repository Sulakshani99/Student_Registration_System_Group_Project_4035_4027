using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Reg_Group.Model
{
    public class NormalUser
    {
        
        public string NormalUsername { get; set; }
        public int NormalUserPassword { get; set; }
        public int NormalUserId { get; set; }
        public UserType UserType { get; set; }
    }
    public enum UserType
    {
        Admin,
        Normal
    }
}
