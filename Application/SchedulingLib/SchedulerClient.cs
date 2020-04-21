using Microsoft.EntityFrameworkCore;
using SchedulingLib.models;

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
    }
}