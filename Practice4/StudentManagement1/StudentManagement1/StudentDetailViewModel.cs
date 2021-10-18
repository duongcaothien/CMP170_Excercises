using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static StudentManagement1.StudentSearchViewModel;

namespace StudentManagement1

{
    class StudentDetailViewModel : BaseViewModel
    {


        private string Gender;
        private int StudentId;
        private string Firstname;
        private string Lastname;
        private string Class1;
        private string Email;
        private bool ismale1;
        private bool ismale;

        public Boolean Ismale
        {
            get => ismale; set
            {
                ismale1 = !value;
                OnPropertyChanged(nameof(Ismale));

            }
        }

        public Boolean IsFemale
        {
            get => !ismale; set
            {
                ismale1 = !value;
                OnPropertyChanged(nameof(IsFemale));

            }
        }


        public int studentId
        {
            get => StudentId; set
            {
                StudentId = value;
                OnPropertyChanged(nameof(studentId));

            }
        }
        public String firstname {
            get => Firstname; set
            {
                Firstname = value;
                OnPropertyChanged(nameof(firstname));

            }
        }
        public String lastname {
            get => Lastname; set
            {
                Lastname = value;
                OnPropertyChanged(nameof(lastname));

            }
        }
        public String gender {
            get => Gender; set
            {
                Gender = value;
                OnPropertyChanged(nameof(gender));

            }
        }
        public String Class {
            get => Class1; set
            {
                Class1 = value;
                OnPropertyChanged(nameof(Class));

            }
        }
        public String email {
            get => Email; set
            {
                Email = value;
                OnPropertyChanged(nameof(email));

            }
        }




        public ICommand SaveCommand { get; set; }

        public StudentDetailViewModel(Student student)
        {
            studentId = student.studentId;
            firstname = student.firstname;
            lastname = student.lastname;
            gender = student.gender;
            Class = student.Class;
            email = student.email;
            Ismale = (gender == "Male");
        }



    }
}
