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
    
    public partial class PasswordEdit : Window
    {
        user user = new user();
        Model1 db = new Model1();
        public PasswordEdit(user user, Model1 db)
        {
            InitializeComponent();
            this.user = user;
            this.db = db;
        }

        private void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(OldPasswordInput.Password))
            {
                MessageBox.Show("Введите старый пароль");
                return;
            }

            if(string.IsNullOrEmpty(NewPasswordInput.Password))
            {
                MessageBox.Show("Введите новый пароль");
                return;
            }

            if(string.IsNullOrEmpty(ConfirmPasswordInput.Password))
            {
                MessageBox.Show("Повторите новый пароль");
                return;
            }

            if(OldPasswordInput.Password != user.password)
            {
                MessageBox.Show("Старый пароль введен неверно");
                return;
            }
            if(OldPasswordInput.Password == NewPasswordInput.Password)
            {
                MessageBox.Show("Новый пароль не может совпадать со старым");
                return;
            }
            if(NewPasswordInput.Password != ConfirmPasswordInput.Password)
            {
                MessageBox.Show("Новый пароль и его подтверждение не совпадают");
                return;
            }
            
            user.password = NewPasswordInput.Password;
            user.isPasswordChange = true;
            db.SaveChanges();

            MessageBox.Show("Пароль успешно изменен");

            this.Close();

        }
    }
}
