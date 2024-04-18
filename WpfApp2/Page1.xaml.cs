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
using PublishingServices;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private ServicesInterface foob;
        public Page1(ServicesInterface foob)
        {
            InitializeComponent();
            this.foob = foob;
        }

        private void UserName_TextChanged(Object sender, RoutedEventArgs e)
        {

        }

        private void password_TextChanged(Object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {

            string registerMsg_ = foob.Registration(userName.Text, password.Text);
            registerMsg.Text = registerMsg_;

        }
    }
}
