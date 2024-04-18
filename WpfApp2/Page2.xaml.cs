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
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private ServicesInterface foob;
        public Page2(ServicesInterface foob)
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

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

            int token = foob.Login(userName.Text, password.Text);
            registerMsg.Text = ""+token;

        }
    }
}
