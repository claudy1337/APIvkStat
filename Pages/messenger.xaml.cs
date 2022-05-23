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
        public String ResponceMessage
        {
            get { return (String)GetValue(ResponceContentMessage); }
            set { SetValue(ResponceContentMessage, value); }
        }
        
        public static readonly DependencyProperty ResponceContentPropertys =
            DependencyProperty.Register("ResponceContentVisibles", typeof(String), typeof(MainWindow));
        public static readonly DependencyProperty ResponceContentMessage =
            DependencyProperty.Register("ResponceMessage", typeof(String), typeof(MainWindow));
        public ObservableCollection<MessageConversations> Member { get; set; }
            = new ObservableCollection<MessageConversations>();
        String token = APIKEY.USER_TOKEN;
        public messenger()
        {
            InitializeComponent();
        }

        private async void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            
            ResponceContentVisibles = "....";
            var result = await Utility.FetchMessageConversations(APIKEY.USER_TOKEN);

            ResponceContentVisibles = Utility.PrettyJson(result.prettyContent);
            
            txtResponce.Text = ResponceContentVisibles;
            Member.Clear();
            var dialog = JsonConvert.DeserializeObject<Message.Root>(txtResponce.Text);
            var dialogs = JsonConvert.DeserializeObject<Message.Item>("");
            
            
            foreach (var item in dialog.response.items)
            {
                //List<string> type = new List<string>() { item.conversation.peer.type };

            }
            lstvMessageType.ItemsSource = dialog.response.items;
            

        }

        private async void lstvMessageType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = lstvMessageType.SelectedItem as Message;
            ResponceContentVisibles = "....";
            var result = await Utility.FetchMessage(APIKEY.USER_TOKEN, "118376632");

            ResponceContentVisibles = Utility.PrettyJson(result.prettyMessage);

            txtResponcemessage.Text = ResponceMessage;
            Member.Clear();
            try
            {
                var dialog = JsonConvert.DeserializeObject<Message>(txtResponce.Text);
                
                
                msg.ItemsSource = dialog.ToString();
            }
            catch (System.NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            //var dialog = JsonConvert.DeserializeObject<VKMessageResponce>(txtResponce.Text);
            //var dialogs = JsonConvert.DeserializeObject<VKMessageResponce.Item>("");


           

            

            

        }
    }
}
