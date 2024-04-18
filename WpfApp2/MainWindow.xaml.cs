using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
using RestSharp;
using Newtonsoft.Json;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ServicesInterface foob;

        public MainWindow()
        {
            InitializeComponent();
            ChannelFactory<ServicesInterface> foobFactory;
            NetTcpBinding tcp = new NetTcpBinding();
            string URL = "net.tcp://localhost:8100/AuthenticationService";
            foobFactory = new ChannelFactory<ServicesInterface>(tcp, URL);
            foob = foobFactory.CreateChannel();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Page1(foob);
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Page2(foob);
        }

        private void ShowAll_Click(object sender, RoutedEventArgs e)
        {
            RestClient restClient = new RestClient("http://localhost:49908/");
            RestRequest restRequest = new RestRequest("api/ShowAll/{id}", Method.Get);
            restRequest.AddUrlSegment("id", "Hi");
            RestResponse restResponse = restClient.Execute(restRequest);
            //Services services = JsonConvert.DeserializeObject<Services>(restResponse.Content);
            Main.Content = new Page3(restResponse.Content);

        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {

            Main.Content = new Page4(foob);
        }
    }
}
