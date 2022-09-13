create database Alumnos;

create table Teacher(
	id int identity primary key,
	name varchar(100) not null,
	lastname varchar(100) not null,
	dni varchar(10) not null,
	birthDate varchar(8) not null,
	gender char (1) not null
);

create table Student(
	id int identity primary key,
	name varchar(100) not null,
	lastname varchar(100) not null,
	dni varchar(10) not null,
	birthDate varchar(10) not null,
	gender char (1) not null,
	admissinDate varchar(10) not null,
	career varchar(200) not null,
	address varchar(200)
);

create table Course(
	id int identity primary key,
	name varchar(200)
);

create table StudentXCourse(
	id int identity primary key,
	courseId int not null foreign key references Course(id),
	studentId int not null foreign key references Student(id),
	year int not null,
	semester int not null
);

create table TeacherXCourse(
	id int identity primary key,
	courseId int not null foreign key references Course(id),
	teacherId int not null foreign key references Teacher(id),
	year int not null,
	semester int not null,
);

select * from student;
select * from teacher;
select * from course;
select * from StudentXCourse;