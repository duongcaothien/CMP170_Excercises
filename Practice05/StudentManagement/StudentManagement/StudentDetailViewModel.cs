using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StudentManagement.SearchStudentViewModel;
using System.Windows.Input;

namespace StudentManagement
{
    class StudentDetailViewModel : BaseViewModel, ICloseable
    {
        private int studentId;
        private string firstname;
        private string lastname;
        private string gender;
        private bool ismale1;
        private string @class;
        private string email;
        private bool isFeMale;

        public int StudentId
        {
            get => studentId; set
            {
                studentId = value;
                OnPropertyChanged(nameof(StudentId));
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
        public String Class { get => @class; set => @class = value; }
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



        private readonly IStudentService m_studentService;
        public StudentDetailViewModel(IStudentService studentService, int studentId)
        {
            m_studentService = studentService;
            var student = m_studentService.LoadStudentById(studentId);
            StudentId = student.studentId;
            Firstname = student.firstname;
            Lastname = student.lastname;
            Gender = student.gender;
            Class = student.Class;
            Email = student.email;
            IsMale = (Gender == "Male");
            SaveCommand = new ConditionalCommand(x => DoSave());
            CancelCommand = new ConditionalCommand(x => Docancel());
        }

        public Student m_student;


        private void DoSave()
        {
            m_student.studentId = StudentId;
            m_student.firstname = Firstname;
            m_student.lastname = Lastname;
            m_student.email = Email;
            m_student.gender = Gender;
            m_student.Class = Class;
            m_studentService.UpdateOrCreateStudent(m_student); ;
        }

        

        public event EventHandler CloseRequest;
        private void Docancel()
        {
            var handler = CloseRequest;
            if (handler != null) handler(this, EventArgs.Empty); ;
        }


    }
}
