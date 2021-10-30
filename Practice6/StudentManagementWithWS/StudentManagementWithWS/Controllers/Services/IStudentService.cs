using System;
using System.Collections.Generic;
using static StudentManagementWithWS.s;

namespace StudentManagementWithWS
{
        public interface IStudentService
        {
            IList<Student> SearchStudent(string keyword, string hutechClass);
            Student LoadStudentById(int id);
            void UpdateOrCreateStudent(Student student);
            void DeleteStudentById(int id);
        }

        public interface ICloseable
        {
            event EventHandler CloseRequest;
        }
    }

