using IS_33.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IS_33.ViewModel
{
    public class MainVm : BaseViewModel
    {
        private List<Student> _students;
        private Student _student;

        public List<Student> Students
        {
            get {  return _students; }
            set
            {
                SetPropertyChanged(ref _students, value);
            }
        }

        public Student Student
        {
            get { return _student; }
            set
            {
                SetPropertyChanged(ref _student, value);
            }
        }

        public MainVm() 
        {
            Students = new List<Student>();

            LoadStudents();
        }

        public void LoadStudents()
        {
            Student = new Student();

            Students.Clear();

            using (var context = new CollegeEntities())
            {
                Students = context.Student.ToList();
            }
        }

        public bool AddStudent()
        {
            try
            {
                using (var context = new CollegeEntities())
                {
                    context.Student.Add(Student);
                    context.SaveChanges();
                }

                LoadStudents();

                return true;
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool DeleteStudent(int id)
        {
            try
            {
                using (var context = new CollegeEntities())
                {
                    var forDelete = context.Student.FirstOrDefault(student => student.Id == id);

                    if (forDelete != null)
                    {
                        context.Student.Remove(forDelete);
                        context.SaveChanges();
                    }

                    LoadStudents();

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
    }
}
