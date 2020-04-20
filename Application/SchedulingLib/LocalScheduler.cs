using Microsoft.EntityFrameworkCore;
using SchedulingLib.models;
using System;

namespace SchedulingLib
{
    public class LocalScheduler
    {
        private SchedulingContext context = new SchedulingContext();

        public LocalScheduler()
        {
            context.Database.Migrate();
        }

        public void NewInstructor(Instructor instructor)
        {
            context.Instructors.Add(instructor);
            context.SaveChanges();
        }
    }
}
