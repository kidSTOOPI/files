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
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        user user;
        Model1 db;
        public EditUser(user user, Model1 db)
        {
            this.user = user;
            this.db = db;
            InitializeComponent();
            RoleBox.ItemsSource = db.role.ToList();
            RoleBox.DisplayMemberPath = "name";
            RoleBox.SelectedValuePath = "id";
            LoginInput.Text = user.login;
            PasswordBox.Password = user.password;
            DatePicker.DisplayDate = user.last_activity;
            IsPasswordChangeBox.IsChecked = user.isPasswordChange;
            RoleBox.SelectedValue = user.Role;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginInput.Text))
            {
                MessageBox.Show("Введите логин");
                return;
            }
            if (string.IsNullOrEmpty(PasswordBox.Password))
            {
                MessageBox.Show("Введите пароль");
                return;
            }  
            this.user.login = LoginInput.Text;
            this.user.password = PasswordBox.Password;
            this.user.last_activity = DatePicker.DisplayDate;
            this.user.isPasswordChange = IsPasswordChangeBox.IsChecked.Value;
            this.user.Role = (int)RoleBox.SelectedValue;
            db.SaveChanges();
            this.Close();
        }
    }
}
