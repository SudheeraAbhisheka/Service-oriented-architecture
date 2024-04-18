using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
using Newtonsoft.Json;
using RestSharp;
using ServiceProvider.Controllers;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3(string json)
        {
            string s = null;
            int i = 0;

            InitializeComponent();

            string[] serviceNames = new string[4];

            List<Services> services = new List<Services>();
            services = System.Text.Json.JsonSerializer.Deserialize<List<Services>>(json);

            foreach (Services service in services)
            {
                serviceNames[i] = service.Name;
                i++;
            }

            textBoxName1.Text = serviceNames[0];
            textBoxName2.Text = serviceNames[1];
            textBoxName3.Text = serviceNames[2];
            textBoxName4.Text = serviceNames[3];
            
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Number1.Visibility = Visibility.Visible;
            Number2.Visibility = Visibility.Visible;
            TextBlock1.Visibility = Visibility.Visible;
            TextBlock2.Visibility = Visibility.Visible;
            textBoxName2.Visibility = Visibility.Hidden;
            textBoxName3.Visibility = Visibility.Hidden;
            textBoxName4.Visibility = Visibility.Hidden;
            Button2.Visibility = Visibility.Hidden;
            Button3.Visibility = Visibility.Hidden;
            Button4.Visibility = Visibility.Hidden;

            if (Number1.Text != "" && Number2.Text != "")
            {
                RestClient restClient = new RestClient("http://localhost:50708/");
                RestRequest restRequest = new RestRequest("api/addtwonumbers/add/{firstNumber}/{secondNumber}", Method.Get);
                restRequest.AddUrlSegment("firstNumber", Int32.Parse(Number1.Text));
                restRequest.AddUrlSegment("secondNumber", Int32.Parse(Number2.Text));
                RestResponse restResponse = restClient.Execute(restRequest);
                Answer.Text = JsonConvert.DeserializeObject<string>(restResponse.Content);
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Number1.Visibility = Visibility.Visible;
            Number2.Visibility = Visibility.Visible;
            Number3.Visibility = Visibility.Visible;
            TextBlock1.Visibility = Visibility.Visible;
            TextBlock2.Visibility = Visibility.Visible;
            TextBlock3.Visibility = Visibility.Visible;
            textBoxName1.Visibility = Visibility.Hidden;
            textBoxName3.Visibility = Visibility.Hidden;
            textBoxName4.Visibility = Visibility.Hidden;
            Button1.Visibility = Visibility.Hidden;
            Button3.Visibility = Visibility.Hidden;
            Button4.Visibility = Visibility.Hidden;

            if(Number1.Text != "" && Number2.Text != "" && Number3.Text != "")
            {
                RestClient restClient = new RestClient("http://localhost:50708/");
                RestRequest restRequest = new RestRequest("api/addthreenumbers/add/{firstNumber}/{secondNumber}/{thirdNumber}", Method.Get);
                restRequest.AddUrlSegment("firstNumber", Int32.Parse(Number1.Text));
                restRequest.AddUrlSegment("secondNumber", Int32.Parse(Number2.Text));
                restRequest.AddUrlSegment("thirdNumber", Int32.Parse(Number3.Text));
                RestResponse restResponse = restClient.Execute(restRequest);
                Answer.Text = JsonConvert.DeserializeObject<string>(restResponse.Content);
            }
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Number1.Visibility = Visibility.Visible;
            Number2.Visibility = Visibility.Visible;
            TextBlock1.Visibility = Visibility.Visible;
            TextBlock2.Visibility = Visibility.Visible;
            textBoxName1.Visibility = Visibility.Hidden;
            textBoxName2.Visibility = Visibility.Hidden;
            textBoxName4.Visibility = Visibility.Hidden;
            Button1.Visibility = Visibility.Hidden;
            Button2.Visibility = Visibility.Hidden;
            Button4.Visibility = Visibility.Hidden;

            if (Number1.Text != "" && Number2.Text != "")
            {
                RestClient restClient = new RestClient("http://localhost:50708/");
                RestRequest restRequest = new RestRequest("api/multwonumbers/mul/{firstNumber}/{secondNumber}", Method.Get);
                restRequest.AddUrlSegment("firstNumber", Int32.Parse(Number1.Text));
                restRequest.AddUrlSegment("secondNumber", Int32.Parse(Number2.Text));
                RestResponse restResponse = restClient.Execute(restRequest);
                Answer.Text = JsonConvert.DeserializeObject<string>(restResponse.Content);
            }
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            Number1.Visibility = Visibility.Visible;
            Number2.Visibility = Visibility.Visible;
            Number3.Visibility = Visibility.Visible;
            TextBlock1.Visibility = Visibility.Visible;
            TextBlock2.Visibility = Visibility.Visible;
            TextBlock3.Visibility = Visibility.Visible;
            textBoxName1.Visibility = Visibility.Hidden;
            textBoxName2.Visibility = Visibility.Hidden;
            textBoxName3.Visibility = Visibility.Hidden;
            Button1.Visibility = Visibility.Hidden;
            Button2.Visibility = Visibility.Hidden;
            Button3.Visibility = Visibility.Hidden;


            if (Number1.Text != "" && Number2.Text != "" && Number3.Text != "")
            {
                RestClient restClient = new RestClient("http://localhost:50708/");
                RestRequest restRequest = new RestRequest("api/multwonumbers/mul/{firstNumber}/{secondNumber}/{thirdNumber}", Method.Get);
                restRequest.AddUrlSegment("firstNumber", Int32.Parse(Number1.Text));
                restRequest.AddUrlSegment("secondNumber", Int32.Parse(Number2.Text));
                restRequest.AddUrlSegment("thirdNumber", Int32.Parse(Number3.Text));
                RestResponse restResponse = restClient.Execute(restRequest);
                Answer.Text = JsonConvert.DeserializeObject<string>(restResponse.Content);
            }
        }
    }
}
