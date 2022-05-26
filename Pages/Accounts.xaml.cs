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
    /// Логика взаимодействия для Accounts.xaml
    /// </summary>
    public partial class Accounts : Page
    {
        public Accounts()
        {
            InitializeComponent();
            Refersh();
        }
        public String ContentAccount
        {
            get { return (String)GetValue(ResponceContentProperty); }
            set { SetValue(ResponceContentProperty, value); }
        }
        public static readonly DependencyProperty ResponceContentProperty =
            DependencyProperty.Register("ContentAccount", typeof(String), typeof(MainWindow));

        public ObservableCollection<VKClientInfo> Members { get; set; }
            = new ObservableCollection<VKClientInfo>();

       

 
        public async void Refersh()
        {
            ContentAccount = "...";
            //ContentFriends = "....";
            var result = await Utility.FetchUserInfo(APIKEY.USER_ID, APIKEY.USER_TOKEN);
            var getresultFriends = await Utility.FetchGetFriends(APIKEY.USER_TOKEN);
            Content = Utility.PrettyJson(result.Content);
           // ContentFriends = Utility.PrettyJson(getresultFriends.Content);
            txtResponce.Text = ContentAccount;
           // txtResponceFriends.Text = ContentFriends;
            Members.Clear();
          //  MemberFriends.Clear();
               var usr = JsonConvert.DeserializeObject<VKClientInfo.Root>(txtResponce.Text);
          //  var friends = JsonConvert.DeserializeObject<VKFriends.Root>(txtResponceFriends.Text);
                usrList.ItemsSource = usr.response;
           // friendsList.ItemsSource = friends.response.items;
        }
    }
}
