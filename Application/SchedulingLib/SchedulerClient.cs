using Microsoft.EntityFrameworkCore;
using SchedulingLib.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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


        public void NewBuilding(Building building)
        {
            context.Buildings.Add(building);
            context.SaveChanges();
        }

        public void NewRoom(Room room)
        {
            context.Rooms.Add(room);
            context.SaveChanges();
        }

        public void NewCourse(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
        }

        public void NewSection(Section section)
        {
            context.Sections.Add(section);
            context.SaveChanges();
        }


        public void EditInstructor(Instructor instructor)
        {
            context.Instructors.Update(instructor);
            context.SaveChanges();
        }

        public void EditBuilding(Building building)
        {
            context.Buildings.Update(building);
            context.SaveChanges();
        }

        public void EditRoom(Room room)
        {
            context.Rooms.Update(room);
            context.SaveChanges();
        }

        public void EditCourse(Course course)
        {
            context.Courses.Update(course);
            context.SaveChanges();
        }

        public void EditSection(Section section)
        {
            context.Sections.Update(section);
            context.SaveChanges();
        }


        public void RemoveInstructor(Instructor instructor)
        {
            context.Instructors.Remove(instructor);
            context.SaveChanges();
        }

        public void RemoveBuilding(Building building)
        {
            context.Buildings.Remove(building);
            context.SaveChanges();
        }

        public void RemoveRoom(Room room)
        {
            context.Rooms.Remove(room);
            context.SaveChanges();
        }

        public void RemoveCourse(Course course)
        {
            context.Courses.Remove(course);
            context.SaveChanges();
        }

        public void RemoveSection(Section section)
        {
            context.Sections.Remove(section);
            context.SaveChanges();
        }


        public async Task<IEnumerable<Instructor>> ListInstructors(CancellationToken token)
        {
            return await context.Instructors.ToListAsync(token);
        }

        public async Task<IEnumerable<Instructor>> ListInstructors(string term, CancellationToken token)
        {
            if (term.Length == 0) return await ListInstructors(token);

            return await context.Instructors.Where(
                p => p.FirstName.ToLower().Contains(term) ||
                p.LastName.ToLower().Contains(term) ||
                (p.FirstName + " " + p.LastName).ToLower().Contains(term))
                .ToListAsync();
        }
    }
}