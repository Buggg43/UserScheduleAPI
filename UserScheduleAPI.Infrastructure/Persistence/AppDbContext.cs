using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserScheduleAPI.Domain.Entities;

namespace UserScheduleAPI.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<SpecialInfo> SpecialInfos { get; set; }
        public DbSet<UserSpecialInfo> UserSpecialInfos { get; set; }
        public DbSet<ShiftRestriction> ShiftRestrictions { get; set; }

    }
}
