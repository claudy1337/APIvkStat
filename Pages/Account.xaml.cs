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
    /// Логика взаимодействия для Account.xaml
    /// </summary>
    public partial class Account : Page
    {
        public Account()
        {
            InitializeComponent();
            Refersh();
        }
        public String ContentClient
        {
            get { return (String)GetValue(ResponceContentClient); }
            set { SetValue(ResponceContentClient, value); }
        }
        public static readonly DependencyProperty ResponceContentClient =
            DependencyProperty.Register("ContentClient", typeof(String), typeof(MainWindow));

        public ObservableCollection<VKClientInfo> Members { get; set; }
            = new ObservableCollection<VKClientInfo>();
        private async void updClick_Click(object sender, RoutedEventArgs e)
        {

        }
        public async void Refersh()
        {
            ContentClient = "....";
            var result = await Utility.FetchUserInfo(APIKEY.USER_ID, APIKEY.USER_TOKEN);
            ContentClient = Utility.PrettyJson(result.Content);
            txtResponce.Text = ContentClient;
            Members.Clear();
            var usr = JsonConvert.DeserializeObject<VKClientInfo.Root>(txtResponce.Text);
            usrList.ItemsSource = usr.response;
        }
        private async void cl_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
