﻿using System;
using static TeacherManagement.SearchTeacherViewModel;

namespace TeacherManagement
{
    class TeacherDetailViewModel : BaseViewModel, ICloseable
    {
        private int teacherId;
        private string firstname;
        private string lastname;
        private string gender;
        private bool ismale1;
        private string @class;
        private string email;
        

        public int TeacherId
        {
            get => teacherId; set
            {
                teacherId = value;
                OnPropertyChanged(nameof(TeacherId));
            }
        }

        public String Firstname
        {
            get => firstname;
            set
            {
                firstname = value;
                OnPropertyChanged(nameof(Firstname));
            }
        }
        public String Lastname
        {
            get => lastname;
            set
            {
                lastname = value;
                OnPropertyChanged(nameof(Lastname));
            }
        }
        public String Gender { get => gender; set => gender = value; }
        public String Class
        {
            get => @class;
            set
            {
                @class = value;
                OnPropertyChanged(nameof(Class));
            }
        }
        public String Email { get => email; set => email = value; }


        public Boolean IsMale
        {
            get => ismale1;
            set
            {
                ismale1 = value;
                OnPropertyChanged(nameof(IsMale));
            }
        }

        public ConditionalCommand SaveCommand { get; }
        public ConditionalCommand CancelCommand { get; }

        public Boolean IsFeMale
        {
            get => !ismale1;
            set
            {
                ismale1 = !value;
                OnPropertyChanged(nameof(IsFeMale));
            }
        }



        private readonly ITeacherService m_teacherService;
        public TeacherDetailViewModel(ITeacherService teacherService, int teacherId)
        {
            m_teacherService = teacherService;
            var teacher = m_teacherService.LoadTeacherById(teacherId);
            TeacherId = teacher.teacherId;
            Firstname = teacher.firstname;
            Lastname = teacher.lastname;
            Gender = teacher.gender;
            Class = teacher.Class;
            Email = teacher.email;
            IsMale = (Gender == "Male");
            SaveCommand = new ConditionalCommand(x => DoSave());
            CancelCommand = new ConditionalCommand(x => Docancel());
        }



        private void DoSave()
        {
            Teacher m_teacher = new Teacher();
            m_teacher.teacherId = TeacherId;
            m_teacher.firstname = Firstname;
            m_teacher.lastname = Lastname;
            m_teacher.email = Email;
            m_teacher.gender = Gender;
            m_teacher.Class = Class;
            m_teacherService.UpdateOrCreateTeacher(m_teacher); ;
            var handler = CloseRequest;
            if (handler != null) handler(this, EventArgs.Empty); ;
        }




        public event EventHandler CloseRequest;
        private void Docancel()
        {
            var handler = CloseRequest;
            if (handler != null) handler(this, EventArgs.Empty); ;
        }

    }
}
