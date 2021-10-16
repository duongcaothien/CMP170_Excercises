﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Input;

namespace StudentManagement1
{
    class StudentSearchViewModel : BaseViewModel
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
        private bool ismale1;

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
            var jsonString = File.ReadAllText("Student_Data.json");
            var students = JsonSerializer.Deserialize<List<Student>>(jsonString);
            Students = new ObservableCollection<Student>(students);
            OpenDetailCommand = new ConditionalCommand(x => DoOpenDetail());
        }

        public void DoOpenDetail()
        {
            var studentDetailViewModel = new StudentDetailViewModel(SelectedStudent);
            Window1 studentDetail = new Window1();
            studentDetail.DataContext = studentDetailViewModel;
            studentDetail.ShowDialog();
        }
        
       
    }
}