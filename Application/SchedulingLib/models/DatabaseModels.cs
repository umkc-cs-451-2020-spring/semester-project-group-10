using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulingLib.models
{
    public class Building
    {
        public int BuildingId { get; set; }
        public string BuildingName { get; set; }

        public List<Rooms> Rooms { get; set; }
    }

    public class Room
    {
        public int RoomId { get; set; }
        public int RoomSize { get; set; }
        public string RoomNumber { get; set; }

        public int BuildingId { get; set; }
        public Buildings Buildings { get; set;}

        public List<Sections> Sections { get; set; }
    }

    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int CourseSize { get; get; }

        public List<Sections> Sections { get; set; }
    }

    public class Instructor
    {
        public int InstructorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Sections> Sections { get; set; }
    }

    public class Section
    {
        public int SectionId { get; set; }
        public string DayOfWeek { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }

        public int RoomId { get; set; }
        public Rooms Rooms { get; set; }

        public int CourseId { get; set; }
        public Courses Courses { get; set; }

        public int InstructorId { get; set; }
        public Instructor Instructors { get; set; }

    }
}
