using Students.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Students.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        DBEntities _db;
        public StudentController()
        {
            _db = new DBEntities();
        }
        public ActionResult Index()
        {
            List<Table> persons = _db.Tables.ToList();
            List<Student> students = new List<Student>();

            foreach (var person in persons)
            {
                students.Add(new Student
                {
                    Id = person.Id,
                    Name = person.Name,
                    LastName = person.LastName,
                    DisplayBirthDate = person.BirthDate.ToShortDateString(),
                    BirthDate = person.BirthDate,
                    City = person.City,
                    Email = person.Email
                });
            }

            return View(students);
        }
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult AddStudent(Student student)
        {
            // Save
            _db.Tables.Add(new Table
            {
                Name = student.Name,
                LastName = student.LastName,
                BirthDate = student.BirthDate,
                City = student.City,
                Email = student.Email
            });
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var person = _db.Tables.Find(id);

            if (person != null)
            {
                _db.Tables.Remove(person);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var person = _db.Tables.Find(id);
            Student student = new Student();
            student.Name = person.Name;
            student.LastName = person.LastName;
            student.BirthDate = person.BirthDate;
            student.City = person.City;
            student.Email = person.Email;
            return View(student);    
        }
        public ActionResult EditStudent(Student student)
        {
           _db.Tables.Find(student.Id).Name = student.Name;
           _db.Tables.Find(student.Id).LastName = student.LastName;
           _db.Tables.Find(student.Id).BirthDate= student.BirthDate;
           _db.Tables.Find(student.Id).City = student.City;
           _db.Tables.Find(student.Id).Email= student.Email;
           _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var person = _db.Tables.Find(id);
            return View(person);
        }
    }
}