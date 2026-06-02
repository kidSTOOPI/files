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
using WpfApp2.Data;
using WpfApp2.Windows;

namespace WpfApp2.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        Model1 db = new Model1();
        public AdminPage()
        {
            InitializeComponent();
            UserDataGrid.ItemsSource = db.user.ToList();

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            new AddUser().ShowDialog();
            MessageBox.Show("Пользователь добавлен");
            UserDataGrid.ItemsSource = db.user.ToList();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            user user = UserDataGrid.SelectedItem as user;
            new EditUser(user,db).ShowDialog();
            MessageBox.Show("Пользователь изменён");
            UserDataGrid.ItemsSource = db.user.ToList();
        }
         private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            user user = UserDataGrid.SelectedItem as user;

            if(StaticObject.user.id == user.id)
            {
                MessageBox.Show("Невозможно удалить самого себя");
                UserDataGrid.ItemsSource = db.user.ToList();
                return;
            }
            if(MessageBox.Show("Вы уверены, что хотите удалить пользователя?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                db.user.Remove(user);
                db.SaveChanges();
                MessageBox.Show("Пользователь удален");
                UserDataGrid.ItemsSource = db.user.ToList();
            }
        }
    }
}
