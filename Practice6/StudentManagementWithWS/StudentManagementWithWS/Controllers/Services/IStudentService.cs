using System;
using System.Collections.Generic;

namespace StudentManagementWithWS
{
        public interface IStudentService
        {
            IList<Student> SearchStudent(string keyword, string hutechClass);
            Student LoadStudentById(int id);
            void UpdateOrCreateStudent(Student student);
            void DeleteStudentById(int id);
        }
    }

