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
using System.Windows.Shapes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
using System.Reflection;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Leaf.xNet;

namespace UIKitTutorials
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void oauth_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var current_user = new Leaf.xNet.HttpRequest();
                string responce = current_user.Get("https://oauth.vk.com/token?grant_type=password&client_id=2274003&client_secret=hHbZxrka2uZ6jB1inYsH&username=" + txtLogin.Text + "&password=" + txtPassword.Text).ToString();
                dynamic json = JObject.Parse(responce);
                APIKEY.USER_TOKEN = json.access_token;
                APIKEY.USER_ID = json.user_id;
            }
            catch (Leaf.xNet.HttpException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
