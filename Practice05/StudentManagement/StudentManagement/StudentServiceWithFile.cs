using System.Collections.Generic;
using System.IO;
using System.Linq;
using static StudentManagement.SearchStudentViewModel;
using System.Text.Json;

namespace StudentManagement
{
    public class StudentServiceWithFile : IStudentService
    {
        private List<Student> m_students;
        public StudentServiceWithFile()
        {
            var data = File.ReadAllText("Student_Data.json");
            m_students = JsonSerializer.Deserialize<List<Student>>(data);
        }
        public void DeleteStudentById(int id)
        {
            var deleteStudent = LoadStudentById(id);
            if (deleteStudent != null)
            {
                m_students.Remove(deleteStudent);
            }

        }
        public Student LoadStudentById(long id)
        {
            return m_students.FirstOrDefault(x => x.studentId == id);
        }
        IList<Student> IStudentService.SearchStudent(string keyword, string hutechclass)
        {
            var result = m_students.Where(s => (s.Class == hutechclass || hutechclass == null) && (s.firstname == keyword || s.lastname == keyword || keyword == null))
                               .OrderBy(s => s.firstname).ToList();


            return result;
        }
        public void UpdateOrCreateStudent(Student student)
        {
            if (student.studentId > 0)
            {
                var updatedStudent = LoadStudentById(student.studentId);
                updatedStudent.lastname = student.lastname;
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
