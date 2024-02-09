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
using static Task_1.SearchPage;
using static Task_1.ListIform;

namespace Task_1
{
    /// <summary>
    /// Логика взаимодействия для Change.xaml
    /// </summary>
    public partial class Change : Window
    {
        public Change()
        {
            InitializeComponent();
            if (!flag)
            {
            }
            else
            {
                rb1.Visibility = Visibility.Hidden;
                rb2.Visibility = Visibility.Hidden;
                rb3.Visibility = Visibility.Hidden;
                rb5.Visibility = Visibility.Hidden;
            }
        }

        int count = 0;

        private void rb1_Checked(object sender, RoutedEventArgs e)
        {
            count = 1;
        }

        private void rb2_Checked(object sender, RoutedEventArgs e)
        {
            count = 2;
        }

        private void rb3_Checked(object sender, RoutedEventArgs e)
        {
            count = 3;
        }

        private void rb4_Checked(object sender, RoutedEventArgs e)
        {
            count = 4;
        }

        private void rb5_Checked(object sender, RoutedEventArgs e)
        {
            count = 5;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string newProperty = tbNewProperty.Text;
            string PhoneNumber = tbPhoneProperty.Text;

            if (flag == true)
            {
                Manager manager = new Manager();
                manager.ChangeProperty(newProperty, PhoneNumber, count);
            }
            else
            {
                Consultant consultant = new Consultant();
                consultant.ChangeProperty(newProperty, PhoneNumber, count);
            }
        }
    }
}
