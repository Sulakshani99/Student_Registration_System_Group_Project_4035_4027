using Microsoft.EntityFrameworkCore;
using Student_Reg_Group.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Reg_Group
{
    public class AdminContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        private readonly string _path = @"D:\Academic\Academic\Semester 3\EE3250-GUI Programming [C#]\Student_Reg_GroupNEW\Student_Reg_GroupNEW\Student_Reg_Group\Student_Reg_Group\Admins.db";

        protected override void
            OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data source={_path}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add initial user data
            modelBuilder.Entity<Admin>().HasData(
                new Admin {AdminUsername="admin", AdminPassword=1, UserType = UserType.Admin, AdminId=1 }
                
            );

           

            

        }

    }
}
