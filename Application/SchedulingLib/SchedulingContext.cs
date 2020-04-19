using Microsoft.EntityFrameworkCore;
using SchedulingLib.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulingLib
{
    class SchedulingContext : DbContext
    {
        public DbSet<Instructor> Instructors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=courseSchedule.db");
    }
}
