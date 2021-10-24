using System;
using System.Collections.Generic;
using static StudentManagement.SearchStudentViewModel;

namespace StudentManagement
{
    public interface IStudentService
    {
        IList<Student> SearchStudent(string keyword, string hutechclass);
        Student LoadStudentById(long id);
        void UpdateOrCreateStudent(Student student);
        void DeleteStudentById(int id);
    }

    public interface ICloseable
    {
        event EventHandler CloseRequest;
    }
}
