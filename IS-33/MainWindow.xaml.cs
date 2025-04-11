using IS_33.Model;
using IS_33.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IS_33
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainVm();
        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainVm).LoadStudents();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddStudentWindow((DataContext as MainVm).Student);

            addWindow.Owner = this;

            addWindow.ShowDialog();
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var result = (DataContext as MainVm).DeleteStudent((mainDG.SelectedItem as Student).Id);

            if (!result)
            {
                return;
            }

            MessageBox.Show("Объект успешно удалён.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
