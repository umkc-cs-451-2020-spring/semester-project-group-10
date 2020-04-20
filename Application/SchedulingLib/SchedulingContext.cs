using Microsoft.EntityFrameworkCore;
using SchedulingLib.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulingLib
{
    class SchedulingContext : DbContext
    {
        public DbSet<Building> Building { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Instructor> Instructor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=courseSchedule.db");
    }
}
