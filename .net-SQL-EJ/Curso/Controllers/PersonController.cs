using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Cursos.Models;

namespace Curso.Controllers
{
    public class PersonController : Controller
    {

        private Models.AlumnosEntities db = new Models.AlumnosEntities();
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Student()
        {
            SetGenderList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Student(Student student)
        {
            if (ModelState.IsValid)
            {
                Models.Student studentDb = new Models.Student();

                studentDb.name = student.name;
                studentDb.lastname = student.lastName;
                studentDb.dni = student.DNI;
                studentDb.birthDate = student.birthDate;
                studentDb.gender = student.gender;
                studentDb.admissinDate = student.admissionDate;
                studentDb.career = student.career;
                studentDb.address = student.address;
                db.Entry(studentDb).State = EntityState.Added;

                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewBag.Mensaje = "No se pudo cargar el Estudiante.";
                    SetGenderList(student.gender);
                    return View(student);
                }
                ViewBag.Mensaje = "Alumno cargado con exito.";
                SetGenderList();
                return View();
            }
            SetGenderList(student.gender);
            return View();
        }

        public ActionResult Teacher()
        {
            SetGenderList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Teacher(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                Models.Teacher teacherDb = new Models.Teacher();

                teacherDb.name = teacher.name;
                teacherDb.lastname = teacher.lastName;
                teacherDb.dni = teacher.DNI;
                teacherDb.birthDate = teacher.birthDate;
                teacherDb.gender = teacher.gender;
                db.Entry(teacherDb).State = EntityState.Added;

                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewBag.Mensaje = "No se pudo cargar el Profesor.";
                    SetGenderList(teacher.gender);
                    return View(teacher);
                }
                ViewBag.Mensaje = "Profesor cargado con exito.";
                SetGenderList();
                return View();
            }
            SetGenderList(teacher.gender);
            return View();
        }
        public void SetGenderList(string selected = "")
        {
            List<SelectListItem> genders = new List<SelectListItem>();
            genders.Add(new SelectListItem { Value = "M", Text = "Masculino" });
            genders.Add(new SelectListItem { Value = "F", Text = "Femenino" });
            genders.Add(new SelectListItem { Value = "O", Text = "Otro" });

            ViewBag.gender = new SelectList(genders, "Value", "Text", selected);
        }

    }
}