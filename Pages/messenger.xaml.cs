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
    /// Логика взаимодействия для messenger.xaml
    /// </summary>
    public partial class messenger : Page
    {
        public String ResponceContentVisibles
        {
            get { return (String)GetValue(ResponceContentPropertys); }
            set { SetValue(ResponceContentPropertys, value); }
        }
        public static readonly DependencyProperty ResponceContentPropertys =
            DependencyProperty.Register("ResponceContentVisibles", typeof(String), typeof(MainWindow));

        public ObservableCollection<VKGroupMember> Member { get; set; }
            = new ObservableCollection<VKGroupMember>();
        public messenger()
        {
            InitializeComponent();
        }

        private async void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            String token = APIKEY.USER_TOKEN;
            ResponceContentVisibles = "....";
            var result = await Utility.FetchMessageConversations(APIKEY.USER_TOKEN);
            ResponceContentVisibles = Utility.PrettyJson(result.prettyContent);
            txtResponce.Text = ResponceContentVisibles;
            Member.Clear();
            var usr = JsonConvert.DeserializeObject<Message.Root>(txtResponce.Text);
            lstvMessageType.ItemsSource = usr.response.items;
        }
    }
}
