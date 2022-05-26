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
using VkNet;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Enums.Filters;

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

        public ObservableCollection<MessageConversations> Members { get; set; }
            = new ObservableCollection<MessageConversations>();

        public messenger()
        {
            InitializeComponent();
            Refresh();
        }

        private async void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
        public async void Refresh()
        {
            ResponceContentVisibles = "....";
            var result = await Utility.FetchMessageConversations(APIKEY.USER_TOKEN);
            ResponceContentVisibles = Utility.PrettyJson(result.prettyContent);
            txtResponce.Text = ResponceContentVisibles;
            Member.Clear();
            var dialog = JsonConvert.DeserializeObject<Model.Message.Root>(txtResponce.Text);
            var dialogs = JsonConvert.DeserializeObject<Model.Message.Item>("");
            lstvMessageType.ItemsSource = dialog.response.items;
        }
        int selected_chat;
        private async void lstvMessageType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshDialog();
            
        }
        public async void RefreshDialog()
        {
            var selected = lstvMessageType.SelectedItem as Model.Message.Item;
            selected_chat = selected.conversation.peer.local_id;
            txtResponcemessage.Text = "....";
            var result = await Utility.FetchMessage(APIKEY.USER_TOKEN, selected.ToString());
            ResponceMessage = Utility.PrettyJson(result.prettyMessage);
            txtResponcemessage.Text = ResponceMessage;
            Members.Clear();
            var usr = JsonConvert.DeserializeObject<MessageGetTest.Root>(txtResponcemessage.Text);
            var reverse = usr.response.items.ToArray().Reverse();
            msg.ItemsSource = reverse;
        }
        private void msgSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtSend.Text == null)
                {
                    RefreshDialog();
                }
                VkApi api = new VkApi();
                api.Authorize(new ApiAuthParams()
                {
                    AccessToken = APIKEY.USER_TOKEN,
                    Password = APIKEY.password,
                    Login = APIKEY.login,
                    ApplicationId = 8165811,
                    Settings = Settings.All
                });


                api.Messages.Send(new MessagesSendParams()
                {
                    UserId = selected_chat,
                    PeerId = selected_chat,
                    Message = txtSend.Text,
                    RandomId = new Random().Next()
                });
                RefreshDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ограничена отправка");
            }
        }
    }
}
