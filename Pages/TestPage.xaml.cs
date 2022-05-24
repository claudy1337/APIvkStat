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
            usrList.ItemsSource = null;
            Refersh();
        }
        public String Content
        {
            get { return (String)GetValue(ResponceContentProperty); }
            set { SetValue(ResponceContentProperty, value); }
        }
        public static readonly DependencyProperty ResponceContentProperty =
            DependencyProperty.Register("Content", typeof(String), typeof(MainWindow));

        public ObservableCollection<VKClientInfo> Members { get; set; }
            = new ObservableCollection<VKClientInfo>();

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            
            
        }
        public async void Refersh()
        {
            Content = "....";
            var result = await Utility.FetchGetFriends(APIKEY.USER_TOKEN);
            Content = Utility.PrettyJson(result.Content);
            txtResponce.Text = Content;
            Members.Clear();
            var usr = JsonConvert.DeserializeObject<VKFriends.Root>(txtResponce.Text);
            usrList.ItemsSource = usr.response.items;
        }
    }
}
