using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulingLib
{
    internal class LocalSchedulerClient : SchedulerClient
    {
        public LocalSchedulerClient(string databasePath) : base(databasePath)
        {
            context.Database.Migrate();
        }
    }
}
