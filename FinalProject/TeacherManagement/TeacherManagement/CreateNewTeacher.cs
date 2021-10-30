using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TeacherManagement.SearchTeacherViewModel;

namespace TeacherManagement
{
    class CreateNewTeacher : BaseViewModel , ICloseable
    {

        private int teacherId;
        private string firstname;
        private string lastname;
        private string gender;
        private bool ismale1;
        private string Class;
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


        public Boolean IsMale
        {
            get => ismale1;
            set
            {
                ismale1 = value;
                OnPropertyChanged(nameof(IsMale));
            }
        }

        public String Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public String @class
        {
            get => Class;
            set
            {
                Class = value;
                OnPropertyChanged(nameof(@class));
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
        public CreateNewTeacher(ITeacherService teacherService, int teacherId)
        {
            m_teacherService = teacherService;
            var teacher = m_teacherService.LoadTeacherById(teacherId);
            SaveCommand = new ConditionalCommand(x => DoSave());
            CancelCommand = new ConditionalCommand(x => Docancel());
        }



        private void DoSave()
        {
            Teacher m_teacher = new Teacher();
            m_teacher.teacherId = TeacherId;
            m_teacher.firstname = Firstname;
            m_teacher.lastname = Lastname;
            m_teacher.gender = Gender;
            m_teacher.email = Email;
            m_teacherService.UpdateOrCreateTeacher(m_teacher); ;
            Docancel();
        }




        public event EventHandler CloseRequest;
        private void Docancel()
        {
            var handler = CloseRequest;
            if (handler != null) handler(this, EventArgs.Empty); ;
        }

    }
}
