CREATE TABLE Buildings (
buildingID INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL, 
building_name CHAR (5, 50)
);

CREATE TABLE Courses (
courseID INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL, 
course_name VARCHAR (1, 50) NOT NULL, 
course_size INTEGER NOT NULL
);

CREATE TABLE Instructors (
instructorID INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL, 
first_name CHAR (1, 20) NOT NULL, 
last_name CHAR (1, 20) NOT NULL, 
availability CHAR (1, 1) NOT NULL
);

CREATE TABLE Rooms (
roomID INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL, 
room_size INTEGER NOT NULL, 
room_number VARCHAR (3, 6), 
buildingID REFERENCES Building (BuildingID) ON DELETE CASCADE MATCH SIMPLE NOT NULL
);

CREATE TABLE Sections (
section_number INTEGER PRIMARY KEY NOT NULL UNIQUE, 
day_of_week CHAR (1, 7) NOT NULL, 
end_time INT (4, 4) NOT NULL, 
start_time INT (4, 4) NOT NULL, 
roomID INTEGER REFERENCES Rooms (roomID) ON DELETE CASCADE NOT NULL, 
instructorID INTEGER REFERENCES Instructors (instructorID) ON DELETE CASCADE NOT NULL, 
courseID INTEGER REFERENCES Courses (courseID) ON DELETE CASCADE NOT NULL
);

INSERT INTO Buildings (buildingID, building_name)
VALUES
(1, 'Katz Hall'),
(2, 'Flarsheim Hall'),
(3, 'Miller Nichols Library'),
(4, 'Haag Hall');

INSERT INTO Courses (courseID, course_name, course_size)
VALUES
(1, 'CS101', 10),
(2, 'CS201', 20),
(3, 'CS404', 25),
(4, 'CS451R', 50),
(5, 'CS470', 20),
(6, 'CS121', 15);

INSERT INTO Instructors (instructorID, first_name, last_name, availability)
VALUES
(1, 'Kendall', 'Bingham', 'N'),
(2, 'Brian', 'Hare', 'N'),
(3, 'Billy', 'Bob', 'T'),
(4, 'Mohammad', 'Kuhail', 'N');

INSERT INTO Rooms (roomID, room_size, room_number, buildingID)
VALUES
(1, 30, '101', 1),
(2, 40, '101', 2),
(3, 55, '101', 3),
(4, 60, '101', 4);

INSERT INTO Sections (section_number, day_of_week, end_time, start_time, roomID, instructorID, courseID)
VALUES
(1, 'MWF', 1350, 1300, 1, 1, 3),
(2, 'M', 1900, 2200, 4, 2, 4),
(3, 'TT', 1115, 1000, 4, 3, 3);

