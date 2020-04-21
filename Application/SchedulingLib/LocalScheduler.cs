using Microsoft.EntityFrameworkCore;
using SchedulingLib.models;
using System;

namespace SchedulingLib
{
    public class LocalScheduler
    {
        public static SchedulerClient Connect(string path)
        {
            return new LocalSchedulerClient(path);
        }
    }
}
