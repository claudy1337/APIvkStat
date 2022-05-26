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
using UIKitTutorials.vk;
using System.Collections;
using System.Collections.ObjectModel;
using UIKitTutorials.Model;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Net.Security;
using System.IO;
using System.Text.Json;
using UIKitTutorials.Pages;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Reflection;
using JsonSerializer = System.Text.Json.JsonSerializer;


namespace UIKitTutorials.Pages
{
    /// <summary>
    /// Логика взаимодействия для TestPage.xaml
    /// </summary>
    public partial class TestPage : Page
    {
        public TestPage()
        {
            InitializeComponent();
            Refersh();
        }
        public String ResponceMessage
        {
            get { return (String)GetValue(ResponceContentProperty); }
            set { SetValue(ResponceContentProperty, value); }
        }
        public static readonly DependencyProperty ResponceContentProperty =
            DependencyProperty.Register("ResponceMessage", typeof(String), typeof(MainWindow));

        public ObservableCollection<Message> Members { get; set; }
            = new ObservableCollection<Message>();
        public async void Refersh()
        {
           
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ResponceMessage = "....";
            var result = await Utility.FetchMessage(APIKEY.USER_TOKEN, "614977895");
            ResponceMessage = Utility.PrettyJson(result.prettyMessage);
            txtResponce.Text = ResponceMessage;
            Members.Clear();
            var usr = JsonConvert.DeserializeObject<MessageGetTest.Root>(txtResponce.Text);
            
            var reverse = usr.response.items.ToArray().Reverse();
            
            messList.ItemsSource = reverse;



        }
    }
}
