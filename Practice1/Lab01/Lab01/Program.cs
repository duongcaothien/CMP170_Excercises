using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    class program
    {
        /*static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            List<Student> listStudents = new List<Student>();
            Console.Write("Nhap tong so sinh vien N = ");
            int N = Convert.ToInt32(Console.ReadLine());
            Student[] arrStudents = new Student[N];
            Console.WriteLine("Nhap danh sach sinh vien");
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(" nhap sinh vien thu {0}", i + 1);
                Student temp = new Student();
                temp.Input();
                listStudents.Add(temp);
                
            }
            Console.WriteLine("Xuat danh sach sinh vien");
            foreach (Student sv in listStudents)
            {
                sv.Show();
            }
            Console.ReadKey();
        }*/

        class Student
        {
            private string masosinhvien;
            private string hovaten;
            private float diemtrungbinh;
            private string khoa;


            public string Masosinhvien { get; set; }

            public string HovaTen { get; set; }

            public float Diemtrungbinh { get; set; }

            public string Khoa { get; set; }

            public Student()
            {

            }
            public Student(string id, string name, float score, string faculty)
            {
                masosinhvien = id;
                hovaten = name;
                diemtrungbinh = score;
                khoa = faculty;
            }

            public void Input()
            {
                Console.Write("nhap MSSV: ");
                masosinhvien = Console.ReadLine();
                Console.Write("nhap ho va ten: ");
                hovaten = Console.ReadLine();
                Console.Write("nhap diem TB: ");
                diemtrungbinh = float.Parse(Console.ReadLine());

                Console.Write("nhap khoa: ");
                khoa = Console.ReadLine();
            }
            public void Show()
            {
                Console.WriteLine("MSSV: {0} Ho va ten : {1} Khoa: {2} DiemTB: {3} ", this.masosinhvien, this.hovaten, this.khoa, this.diemtrungbinh);
            }


            /*private static List<Student> NhapDSSinhvien()
             {
                List<Student> listStudents = new List<Student>();
                Console.Write("nhap tong so sinh vien N= ");
                int N = Convert.ToInt32(Console.Read());

                Console.WriteLine(" Nhap danh sach sinh vien");
                for (int i = 0; i < N; i++)
                {
                    Console.WriteLine(" nhap sinh vien thu {0} ", i + 1);
                    Student temp = new Student();
                    temp.Input();
                    listStudents.Add(temp);
                }
                return listStudents
            }

            private static void XuatDSSinhvien(List<Student> listStudent)
            {
                Console.Write("Xuat danh sach sinh vien");
                foreach (Student sv in ListStudent)
                {
                    sv.Show();
                }
            }*/



            static void Main(String[] args)
            {
                Console.OutputEncoding = Encoding.Unicode;
                Console.InputEncoding = Encoding.Unicode;
                List<Student> student = new List<Student>();
                student.Add(new Student("SV01", "Nguyen Van A", 8, "CNTT"));
                student.Add(new Student("SV02", "Nguyen Van A", 7, "CNTT"));
                student.Add(new Student("SV03", "Nguyen Van A", 9, "QTKD"));
                student.Add(new Student("SV04", "Nguyen Van A", 10, "CNTT"));
                student.Add(new Student("SV05", "Nguyen Van A", 5, "NHKS"));
                student.Add(new Student("SV06", "Nguyen Van A", 3, "CNTT"));
                student.Add(new Student("SV07", "Nguyen Van A", 4, "CNTT"));

                
                var cnttStudents = student.FindAll(x => x.khoa == "CNTT");              
                

                Console.WriteLine("=====Cau1");
                foreach (var item in cnttStudents)
                {
                    Console.WriteLine(item.masosinhvien + " " + item.khoa);
                }

                var TBScore = student.FindAll(x => x.diemtrungbinh >= 5);
                Console.WriteLine("=====Cau2");
                foreach (var item in TBScore)
                {
                    Console.WriteLine(item.hovaten + " " + item.diemtrungbinh + " " + item.khoa);
                }

                var cau3 = student.OrderBy(x => x.diemtrungbinh >= 5).ToList();

                Console.WriteLine("=====Cau3");
                foreach (var item in cau3)
                {
                    if (item.khoa == "CNTT")
                    {


                        Console.WriteLine("MSSV:{0} Họ Tên:{1} Khoa:{2} ĐiêmTB:{3}", item.masosinhvien,
                        item.hovaten, item.khoa, item.diemtrungbinh);
                    }
                }

                var cau4 = student.FindAll(x => (x.diemtrungbinh >= 5 && x.khoa == "CNTT"));

                Console.WriteLine("=====Cau4");
                    foreach (var item in cau4)
                {
                    if (item.khoa == "CNTT")
                        Console.WriteLine(item.masosinhvien + " " + item.khoa + " " + " " + item.diemtrungbinh);
                }



                var findmax = cnttStudents.Max(x => x.diemtrungbinh);
                Console.WriteLine("=====Cau5");
                var Cnttmost = student.FindAll(x => x.diemtrungbinh == findmax && x.khoa == "CNTT");
                    foreach (var item in Cnttmost)
                {
                    Console.WriteLine(item.masosinhvien);
                }
                Console.ReadKey();




            }

        }


    }
}
    
    
