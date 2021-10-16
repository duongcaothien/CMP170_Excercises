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
    class StudentDetailViewModel
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        private string gender1;
        private string ismale1;
        

        public int studentId { get; set; }
        public String firstname { get; set; }
        public String lastname { get; set; }
        public String gender { get; set; }
        public String Class { get; set; }
        public String email { get; set; }

        


        public ICommand SaveCommand { get; set; }
        public StudentDetailViewModel(Student student)
        {
            studentId = student.studentId;
            firstname = student.firstname;
            lastname = student.lastname;
            gender = student.gender;
            Class = student.Class;
            email = student.email;
            
        }



    }
}
