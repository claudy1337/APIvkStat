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
    /// Логика взаимодействия для test.xaml
    /// </summary>
    public partial class test : Page
    {
        public String ResponceMessage
        {
            get { return (String)GetValue(ResponceContentMessage); }
            set { SetValue(ResponceContentMessage, value); }
        }
        public static readonly DependencyProperty ResponceContentMessage =
            DependencyProperty.Register("ResponceMessage", typeof(String), typeof(MainWindow));
        public ObservableCollection<MessageConversations> Member { get; set; }
            = new ObservableCollection<MessageConversations>();
         String token = APIKEY.USER_TOKEN;
        public test()
        {
            InitializeComponent();
        }

        private async void cl_Click(object sender, RoutedEventArgs e)
        {
           
            ResponceMessage = "....";
            var result = await Utility.FetchMessage(APIKEY.USER_TOKEN, "118376632");

            ResponceMessage = Utility.PrettyJson(result.prettyMessage);

            txtResponce.Text = ResponceMessage;
            Member.Clear();
           
        }
    }
}
