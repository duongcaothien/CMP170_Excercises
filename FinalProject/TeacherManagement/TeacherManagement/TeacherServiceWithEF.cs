using System;
using System.Collections.Generic;
using System.Linq;
using static TeacherManagement.SearchTeacherViewModel;

namespace TeacherManagement
{
    public class TeacherServiceWithEF : ITeacherService
    {
        public TeacherServiceWithEF()
        {
            using (var ctx = new UniversityContext())
            {
                ctx.Database.EnsureCreated();
            }
        }

        public void DeleteTeacherById(int id)
        {
            using (var ctx = new UniversityContext())
            {
                var deletedTeacher = ctx.Teachers.Find(id);
                ctx.Teachers.Remove(deletedTeacher);
                ctx.SaveChanges();
            }
        }

        public Teacher LoadTeacherById(int id)
        {
            using (var ctx = new UniversityContext())
            {
                return ctx.Teachers.Find(id);
            }
        }

        public IList<Teacher> SearchTeacher(string keyword, string hutechclass)
        {
            using (var ctx = new UniversityContext())
            {
                var result = ctx.Teachers.Where(s => (s.Class == hutechclass || String.IsNullOrEmpty(hutechclass)) && (s.firstname == keyword || s.lastname == keyword || string.IsNullOrEmpty(keyword)))
                              .OrderBy(s => s.teacherId).ToList();
                return result;
            }
        }

        public void UpdateOrCreateTeacher(Teacher teacher)
        {
            using (var ctx = new UniversityContext())
            {
                if (teacher.teacherId > 0)
                {
                    var dbTeacher = ctx.Teachers.Find(teacher.teacherId);
                    dbTeacher.firstname = teacher.firstname;
                    dbTeacher.lastname = teacher.lastname;
                    dbTeacher.email = teacher.email;
                    dbTeacher.gender = teacher.gender;
                    dbTeacher.Class = teacher.Class;
                }
                else
                {
                    ctx.Teachers.Add(teacher);
                }
                ctx.SaveChanges();
            }
        }
    }
}

