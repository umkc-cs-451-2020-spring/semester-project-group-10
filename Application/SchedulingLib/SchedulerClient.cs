using Microsoft.EntityFrameworkCore;
using SchedulingLib.models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchedulingLib
{
    public abstract class SchedulerClient
    {
        private protected readonly SchedulingContext context;

        public SchedulerClient(string connectionUrl)
        {
            context = new SchedulingContext(connectionUrl);
        }

        public void NewInstructor(Instructor instructor)
        {
            context.Instructors.Add(instructor);
            context.SaveChanges();
        }

        public async Task<IEnumerable<Instructor>> ListInstructors()
        {
            throw new NotImplementedException();
        }
    }
}