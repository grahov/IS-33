using IS_33.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace IS_33.ViewModel
{
    public class MainVm : BaseViewModel
    {
        private List<Student> _students;
        private Student _selectedStudent;

        public List<Student> Students
        {
            get { return _students; }
            set
            {
                SetPropertyChanged(ref _students, value);
            }
        }

        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                SetPropertyChanged(ref _selectedStudent, value);
            }
        }

        public MainVm() 
        {
            Students = new List<Student>();

            LoadStudents();
        }

        public async void LoadStudents()
        {          
            Students.Clear();

            using (var context = new CollegeEntities())
            {
                Students = await context.Student.ToListAsync();
            }
        }

        public async Task<bool> AddStudent(Student student)
        {
            try
            {
                if (student.Id == 0)
                {
                    using (var context = new CollegeEntities())
                    {
                        context.Student.Add(student);
                        await context.SaveChangesAsync();
                    }

                    LoadStudents();

                    return true;
                }
                else
                {
                    using (var context = new CollegeEntities())
                    {
                        var forEdit = await context.Student.FirstOrDefaultAsync(stud => stud.Id == SelectedStudent.Id);

                        forEdit.Name = SelectedStudent.Name;
                        forEdit.Course = SelectedStudent.Course;

                        await context.SaveChangesAsync();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            
        }

        public async Task<bool> DeleteStudent(int id)
        {
            try
            {
                using (var context = new CollegeEntities())
                {
                    var forDelete = await context.Student.FirstOrDefaultAsync(student => student.Id == id);

                    if (forDelete != null)
                    {
                        context.Student.Remove(forDelete);
                        await context.SaveChangesAsync();
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
