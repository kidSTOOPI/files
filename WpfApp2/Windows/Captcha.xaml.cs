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

namespace WpfApp2.Windows
{
    
    public partial class Captcha : Window
    {
        int _attempts = 3;

        public bool isPassed = false;
        void Img1_Click(object s, MouseButtonEventArgs e) => Rotate(Rot1);
        void Img2_Click(object s, MouseButtonEventArgs e) => Rotate(Rot2);
        void Img3_Click(object s, MouseButtonEventArgs e) => Rotate(Rot3);
        void Img4_Click(object s, MouseButtonEventArgs e) => Rotate(Rot4);

        void Rotate(RotateTransform rot) => rot.Angle = (rot.Angle + 45) % 360;
        public Captcha()
        {
            InitializeComponent();
        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            if (Rot1.Angle == 0 && Rot2.Angle == 0 && Rot3.Angle == 0 && Rot4.Angle == 0)
            {
                MessageBox.Show("Капча пройдена");
                this.isPassed = true;
                this.Close();
            }
            else
            {
                if (--_attempts <= 0)
                {
                    MessageBox.Show("Попытки закончились, пользователь заблокирован, обратитесь к администратору");
                    this.Close();
                    
                }
                else
                {
                    MessageBox.Show($"Неправильно, осталось {_attempts} попыток");
                }
            }
        }
    }
}
