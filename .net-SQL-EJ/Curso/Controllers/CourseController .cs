using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Cursos.Models;

namespace Curso.Controllers
{
    public class CourseController : Controller
    {

        private Models.AlumnosEntities db = new Models.AlumnosEntities();
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Course()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Course(Coursee course)
        {
            if (ModelState.IsValid)
            {
                Models.Course courseDb = new Models.Course();

                courseDb.name = course.name;

                db.Entry(courseDb).State = EntityState.Added;

                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewBag.Mensaje = "No se pudo cargar el Curso.";
                    return View(course);
                }
                ViewBag.Mensaje = "Curso cargado con exito.";
                return View();
            }
            return View();
        }

        public ActionResult StudentXCourse()
        {
            SetCourseList();
            SetStudentsList();
            SetYearsList();
            SetSemestersList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StudentXCourse(StudentXCourse studentXCourse)
        {
            if (ModelState.IsValid)
            {
                Models.StudentXCourse StudentXCourseDb = new Models.StudentXCourse();

                StudentXCourseDb.courseId = studentXCourse.course;
                StudentXCourseDb.studentId = studentXCourse.student;
                StudentXCourseDb.year = studentXCourse.year;
                StudentXCourseDb.semester = studentXCourse.semester;

                db.Entry(StudentXCourseDb).State = EntityState.Added;

                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewBag.Mensaje = "No se pudo asignar el alumno al Curso.";
                    SetCourseList(studentXCourse.course.ToString());
                    SetStudentsList(studentXCourse.student.ToString());
                    SetYearsList(studentXCourse.year.ToString());
                    SetSemestersList(studentXCourse.semester.ToString());
                    return View(StudentXCourseDb);
                }
                ViewBag.Mensaje = "Alumno asignado al curso";
                SetCourseList();
                SetStudentsList();
                SetYearsList();
                SetSemestersList();
                return View();
            }
            SetCourseList(studentXCourse.course.ToString());
            SetStudentsList(studentXCourse.student.ToString());
            SetYearsList(studentXCourse.year.ToString());
            SetSemestersList(studentXCourse.semester.ToString());
            return View();
        }

        public ActionResult StudentXCourseList()
        {
            List<Models.StudentXCourse> studentXCourse =
                db.StudentXCourse
                .OrderBy(q => q.courseId)
                .ToList();
            return View(studentXCourse);
        }

        public void SetCourseList(string selected = "")
        {
            List<Models.Course> courses =
                db.Course
                .ToList();

            ViewBag.course = new SelectList(courses, "id", "name", selected);
        }

        public void SetStudentsList(string selected = "")
        {
            List<Models.Student> students =
                db.Student
                .ToList();

            ViewBag.student = new SelectList(students, "id", "dni", selected);
        }
        public void SetYearsList(string selected = "")
        {
            List<SelectListItem> years = new List<SelectListItem>();
            years.Add(new SelectListItem { Value = "1", Text = "1" });
            years.Add(new SelectListItem { Value = "2", Text = "2" });
            years.Add(new SelectListItem { Value = "3", Text = "3" });
            years.Add(new SelectListItem { Value = "4", Text = "4" });
            years.Add(new SelectListItem { Value = "5", Text = "5" });

            ViewBag.year = new SelectList(years, "Value", "Text", selected);
        }
        public void SetSemestersList(string selected = "")
        {
            List<SelectListItem> semesters = new List<SelectListItem>();
            semesters.Add(new SelectListItem { Value = "1", Text = "1" });
            semesters.Add(new SelectListItem { Value = "2", Text = "2" });

            ViewBag.semester = new SelectList(semesters, "Value", "Text", selected);
        }
    }
}