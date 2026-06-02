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
using WpfApp2.Data;

namespace WpfApp2.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        Model1 db = new Model1 ();
        public AddUser()
        {
            InitializeComponent();
            RoleBox.ItemsSource = db.role.ToList();
            RoleBox.DisplayMemberPath = "name";
            RoleBox.SelectedValuePath = "id";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(LoginInput.Text))
            {
                MessageBox.Show("Введите логин");
                return;
            }
            if (string.IsNullOrEmpty(PasswordBox.Password))
            {
                MessageBox.Show("Введите пароль");
                return;
            }
            if(db.user.Where(x => x.login == LoginInput.Text).ToList().Count() > 0)
            {
                MessageBox.Show("Пользователь с таким логином уже существует");
                return;
            }
            db.user.Add(new user
            {
                login = LoginInput.Text,
                password = PasswordBox.Password,
                last_activity = DatePicker.DisplayDate,
                isPasswordChange = IsPasswordChangeBox.IsChecked.Value,
                Role = (int)RoleBox.SelectedValue,
                blocked = false
            });
            db.SaveChanges();
            StaticObject.DesktopFrame.Refresh();
            this.Close();
        }
    }
}
