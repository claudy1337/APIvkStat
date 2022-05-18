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
    /// Lógica de interacción para PaymentPage.xaml
    /// </summary>
    public partial class PaymentPage : Page
    {
        public PaymentPage()
        {
            InitializeComponent();
        }
        public String Content
        {
            get { return (String)GetValue(ResponceContentProperty); }
            set { SetValue(ResponceContentProperty, value); }
        }
        public static readonly DependencyProperty ResponceContentProperty =
            DependencyProperty.Register("Content", typeof(String), typeof(MainWindow));


        public ObservableCollection<VKGroupMember> Members { get; set; }
            = new ObservableCollection<VKGroupMember>();
        private async void GetUser_Click(object sender, RoutedEventArgs e)
        {
            Content = "....";
            var result = await Utility.FetchUserInfo(txtUserId.Text);
            Content = Utility.PrettyJson(result.Content);
            txtResponce.Text = Content;
            Members.Clear();

            var usr = JsonConvert.DeserializeObject<Users.Items>(txtResponce.Text);
            
        }

        private void savefile_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
