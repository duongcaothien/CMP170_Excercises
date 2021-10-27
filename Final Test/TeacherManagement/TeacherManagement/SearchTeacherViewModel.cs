using System;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace TeacherManagement
{
    public class SearchTeacherViewModel : BaseViewModel
    {
        public class Teacher
        {
            public int teacherId { get; set; }
            public String firstname { get; set; }
            public String lastname { get; set; }
            public String email { get; set; }
            public String gender { get; set; }
            public String Class { get; set; }           
        }

        private String m_Searchkeyword;
        private String m_selectedclass;
        private Teacher m_selectedteacher;

        public String Searchkeyword
        {
            get => m_Searchkeyword;
            set
            {
                m_Searchkeyword = value;
                OnPropertyChanged(nameof(Searchkeyword));
            }
        }
        
        public String SelectedClass
        {
            get => m_selectedclass;
            set
            {
                m_selectedclass = value;
                OnPropertyChanged(nameof(m_selectedclass));
            }
        }
        
        public Teacher SelectedTeacher
        {
            get => m_selectedteacher;
            set
            {
                m_selectedteacher = value;
                OnPropertyChanged(nameof(m_selectedteacher));
            }
        }

        public ObservableCollection<Teacher> Teachers { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand ResetCommand { get; set; }
        public ICommand OpenDetailCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand CreateCommand { get; set; }

        private ITeacherService m_teacherSrv;
        public SearchTeacherViewModel()
        {
            //m_teacherSrv = new TeacherServiceWithFile();
            m_teacherSrv = new TeacherServiceWithEF();
            Teachers = new ObservableCollection<Teacher>(m_teacherSrv.SearchTeacher(string.Empty, string.Empty));
            OpenDetailCommand = new ConditionalCommand(x => DoOpenDetail());
            SearchCommand = new ConditionalCommand(x => DoSearch());
            ResetCommand = new ConditionalCommand(x => DoReset());
            DeleteCommand = new ConditionalCommand(x => DoDelete());
            CreateCommand = new ConditionalCommand(x => DoCreate());
        }

        public void DoReset()
        {
            Searchkeyword = null;
            SelectedClass = null;
            var result = m_teacherSrv.SearchTeacher(Searchkeyword,SelectedClass);
            foreach(var s in result)
            {
                Teachers.Add(s);
            }

        }

        private void DoSearch()
        {
            Teachers.Clear();
            var result = m_teacherSrv.SearchTeacher(Searchkeyword, SelectedClass);
            foreach (var s in result)
            {
                Teachers.Add(s);
            }
        }

        private void DoDelete()
        {
            m_teacherSrv.DeleteTeacherById(SelectedTeacher.teacherId);
        }


        public void DoCreate()
        {
            var TeacherDetailViewModel = new TeacherDetailViewModel(m_teacherSrv, SelectedTeacher.teacherId + 1);
            Window1 teacherDetail = new Window1(TeacherDetailViewModel);
            teacherDetail.DataContext = TeacherDetailViewModel;
            teacherDetail.ShowDialog();
        }

        public void DoOpenDetail()
        {
            var TeacherDetailViewModel = new TeacherDetailViewModel(m_teacherSrv, SelectedTeacher.teacherId);
            Window1 studentDetail = new Window1(TeacherDetailViewModel);
            studentDetail.DataContext = TeacherDetailViewModel;
            studentDetail.ShowDialog();

        }
    }
}
