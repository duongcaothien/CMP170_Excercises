using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Input;

namespace StudentManagement
{
    class StudentSerachViewModel : BaseViewModel
    {
        private string m_searchKeyword;

        public string SearchKeyword
        {
            get => m_searchKeyword;
            set
            {
                m_searchKeyword = value;
                OnPropertyChanged(nameof(SearchKeyword));
            }
        }


        private string m_selectedClass;
        public string SelectedClass
        {
            get => m_selectedClass;
            set
            {
                m_selectedClass = value;
                OnPropertyChanged(nameof(SelectedClass));
            }
        }


        private Student m_selectedStudent;
        public Student SelectedStudent
        {
            get => m_selectedStudent;
            set
            {
                m_selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
            }
        }



        public ObservableCollection<Student> Students { get; set; }

        public ICommand SearchCommand { get; set; }

        public ICommand ResetCommand { get; set; }

        public ICommand OpenDetailCommand { get; set; }


        public class Student
        {
            public int StudentId { get; set; }

            public string Firstname { get; set; }

            public string Lastname { get; set; }

            public string Email { get; set; }

            public string Gender { get; set; }

            public string Class { get; set; }

            public decimal Gpa { get; set; }


        }


        public StudentSerachViewModel()
        {
            var jsonString = File.ReadAllText("Student_Data.json");
            var students = JsonSerializer.Deserialize<List<Student>>(jsonString);
            Students = new ObservableCollection<Student>(students);
        }
    }
}
