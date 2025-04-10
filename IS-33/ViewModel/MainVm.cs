using IS_33.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_33.ViewModel
{
    public class MainVm : BaseViewModel
    {
        private List<Student> _students;

        public List<Student> Students
        {
            get {  return _students; }
            set
            {
                SetPropertyChanged(ref _students, value);
            }
        }

        public MainVm() 
        {
            Students = new List<Student>();

            LoadStudents();
        }

        public void LoadStudents()
        {
            using (var context = new CollegeEntities())
            {
                Students = context.Student.ToList();
            }
        }
    }
}
