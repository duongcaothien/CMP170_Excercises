using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Input;
using static StudentManagement1.IStudentService1;

namespace StudentManagement1
{
    class StudentSearchViewModel : BaseViewModel
    {
        private string m_searchKeyword;
        private IStudentService m_studentSrv;
        private string m_selectedClass;
        private bool ismale1;
        private Student m_selectedStudent;


        public string SearchKeyword
        {
            get => m_searchKeyword;
            set
            {
                m_searchKeyword = value;
                OnPropertyChanged(nameof(SearchKeyword));
            }
        }


        public string SelectedClass
        {
            get => m_selectedClass;
            set
            {
                m_selectedClass = value;
                OnPropertyChanged(nameof(SelectedClass));
            }
        }

        public Student Selectedstudent
        {
            get => m_selectedStudent;
            set
            {
                m_selectedStudent = value;
                OnPropertyChanged(nameof(Selectedstudent));
            }
        }

        public ObservableCollection<Student> Students { get; set; }

        public ICommand SearchCommand { get; set; }

        public ICommand ResetCommand { get; set; }

        public ICommand OpenDetailCommand { get; set; }


        

        public class Student
        {

            public int studentId { get; set; }

            public string firstname { get; set; }

            public string lastname { get; set; }

            public string email { get; set; }

            public string gender { get; set; }

            public string Class { get; set; }

            public decimal gpa { get; set; }


        }

        public StudentSearchViewModel()
        {
            //var jsonString = File.ReadAllText("Student_Data.json");
            //var students = JsonSerializer.Deserialize<List<Student>>(jsonString);
            //Students = new ObservableCollection<Student>(students);
            m_studentSrv = new StudentServiceWithFile();
            Students = new ObservableCollection<Student>(m_studentSrv.SearchStudent(string.Empty, string.Empty));

            SearchCommand = new ConditionalCommand(x => DoSearch());
            ResetCommand = new ConditionalCommand(x => DoReset());
            OpenDetailCommand = new ConditionalCommand(x => DoOpenDetail());
        }

        public void DoOpenDetail()
        {
            var studentDetailViewModel = new StudentDetailViewModel(Selectedstudent);
            Window1 studentDetail = new Window1();
            studentDetail.DataContext = studentDetailViewModel;
            studentDetail.ShowDialog();

        }

        public void DoReset()
        {
            SearchKeyword = null;
            SelectedClass = null;
        }

        private void DoSearch()
        {
            Students.Clear();
            var result = m_studentSrv.SearchStudent(SearchKeyword, m_selectedClass);
            foreach (var s in result)
            {
                Students.Add(s);
            }
        }
        
       
    }
}