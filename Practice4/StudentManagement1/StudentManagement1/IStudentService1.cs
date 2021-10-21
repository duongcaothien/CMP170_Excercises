using System;
using System.Collections.Generic;
using System.Text;
using static StudentManagement1.StudentSearchViewModel;

namespace StudentManagement1
{
    class IStudentService1
    {
        public interface IStudentService
        {
            IList<Student> SearchStudent(String keyword, string hutech);

            Student LoadStudentById(long id);

            void UpdateOrCreateStudent(Student student);

            void DeleteStudentById(int id);
        }
}
