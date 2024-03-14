using System;
using Student_Reg_Group.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Reg_Group
{
    public class NormalUserContext : DbContext
    {
        public DbSet<NormalUser> NormalUsers { get; set; }
        private readonly string path = @"D:\Academic\Academic\Semester 3\EE3250-GUI Programming [C#]\Student_Reg_GroupNEW\Student_Reg_GroupNEW\Student_Reg_Group\Student_Reg_Group\Normalusers.db";

        protected override void
            OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data source={path}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NormalUser>().HasKey(n => n.NormalUserId); // Set Id as primary key
        }

    }
}
