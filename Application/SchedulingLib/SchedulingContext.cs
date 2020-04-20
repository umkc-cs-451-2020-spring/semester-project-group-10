using Microsoft.EntityFrameworkCore;
using SchedulingLib.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulingLib
{
    class SchedulingContext : DbContext
    {
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=courseSchedule.db");
    }
}
