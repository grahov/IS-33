using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using IS_33.Model;
using IS_33.ViewModel;

namespace IS_33
{
    /// <summary>
    /// Логика взаимодействия для AddStudentWindow.xaml
    /// </summary>
    public partial class AddStudentWindow : Window
    {
        public AddStudentWindow(Student student)
        {
            InitializeComponent();

            if (student == null)
            {
                student = new Student();
            }

            DataContext = student;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = await ((this.Owner as MainWindow).DataContext as MainVm).AddStudent(DataContext as Student);

            if (!result)
            {
                MessageBox.Show("Ошибка при добавлнии. См. лог. ошибки в режиме отладки.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            this.Close();
        }
    }
}
