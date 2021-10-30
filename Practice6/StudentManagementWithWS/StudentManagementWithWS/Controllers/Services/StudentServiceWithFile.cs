
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
using static StudentManagementWithWS.s;

namespace StudentManagementWithWS
{
    public class StudentServiceWithFile : IStudentService
    {
        private IList<Student> m_students;
        public StudentServiceWithFile()
        {
            var data = File.ReadAllText(@"C:\Users\Admin\source\repos\CMP170_Excercises\Practice6\StudentManagementWithWS\StudentManagementWithWS\Controllers\Services\Student_Data.json");
            m_students = JsonSerializer.Deserialize<List<Student>>(data);
        }
        public void DeleteStudentById(int id)
        {
            var deletedStudent = LoadStudentById(id);
            if (deletedStudent != null)
            {
                m_students.Remove(deletedStudent);
            }
        }
        public Student LoadStudentById(int id)
        {
            return m_students.FirstOrDefault(x => x.studentId == id);
        }
        public IList<Student> SearchStudent(string keyword, string hutechClass)
        {
            var result = m_students.Where(s => (s.Class == hutechClass || hutechClass == null) && (s.firstname == keyword || s.lastname == keyword || keyword == null))
                               .OrderBy(s => s.firstname).ToList();


            return result;
        }

        public void UpdateOrCreateStudent(Student student)
        {
            if (student.studentId > 0)
            {
                var updatedStudent = LoadStudentById(student.studentId);
                updatedStudent.lastname = student.lastname;
                updatedStudent.firstname = student.firstname;
                updatedStudent.gender = student.gender;
                updatedStudent.Class = student.Class;
                updatedStudent.email = student.email;
            }
            else
            {
                var newStudentId = m_students.Select(s => s.studentId).OrderByDescending(s => s).FirstOrDefault();
                student.studentId = newStudentId + 1;
                m_students.Add(student);
            }
        }

    }
}
