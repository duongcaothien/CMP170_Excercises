using System;
using System.Collections.Generic;
using static TeacherManagement.SearchTeacherViewModel;

namespace TeacherManagement
{
    public interface ITeacherService
    {
        IList<Teacher> SearchTeacher(string keyword, string hutechclass);
        Teacher LoadTeacherById(int id);
        void UpdateOrCreateTeacher(Teacher teacher);
        void DeleteTeacherById(int id);
    }

    public interface ICloseable
    {
        event EventHandler CloseRequest;
    }
}
