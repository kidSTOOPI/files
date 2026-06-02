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
using WpfApp2.Pages;

namespace WpfApp2.Windows
{
    
    public partial class Auth : Window
    {
        Model1 db = new Model1();

        int attentionCount = 0;
        public Auth()
        {
            InitializeComponent();
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginInput.Text))
            {
                MessageBox.Show("Введите логин");
                return;
            }
            if(string.IsNullOrEmpty(PasswordInput.Password))
            {
                MessageBox.Show("Введите пароль");
                return;
            }
            var user = db.user.Where(u => u.login.Trim() == LoginInput.Text.Trim()).First();
            if(user == null)
            {
                MessageBox.Show("Пользователь не найден");
                return;
            }
            if(user.blocked)
            {
                MessageBox.Show("Пользователь заблокирован, обратитесь к администратору");
                return;
            }
            if (user.password == PasswordInput.Password)
            {
                if ((DateTime.Now - (DateTime)user.last_activity).Days > 31)
                {
                    MessageBox.Show("Пользователь заблокирован за неактивность, обратитесь к администратору");
                    user.last_activity = DateTime.Now;
                    user.blocked = true;
                    db.SaveChanges();
                    return;
                }

                var captcha = new Captcha();
                captcha.ShowDialog();
                if (!captcha.isPassed)
                {
                    user.blocked = true;
                    db.SaveChanges();
                    return;
                }

                if (!user.isPasswordChange)
                {
                    MessageBox.Show("Пользователь должен сменить пароль");
                    var changePasswordWindow = new PasswordEdit(user, db);
                    changePasswordWindow.ShowDialog();
                }

                user.last_activity = DateTime.Now;
                db.SaveChanges();

                StaticObject.user= user;

                if (user.Role == 1)
                {
                    var adminWindow = new AdminPage();
                    StaticObject.DesktopFrame.Navigate(adminWindow);
                    this.Close();

                }
                else
                {
                    var userWindow = new ManagerPage();
                    StaticObject.DesktopFrame.Navigate(userWindow);
                    this.Close();
                }

            }
            else
            {
                if (attentionCount == 3)
                {
                    MessageBox.Show("Пользователь заблокирован за 3 неудачные попытки входа, обратитесь к администратору");
                    user.blocked = true;
                    return;
                }

                MessageBox.Show("Неверный пароль");
                attentionCount++;
            }
        }
    }
}
