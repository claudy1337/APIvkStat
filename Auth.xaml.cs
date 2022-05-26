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
using VkNet;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Enums.Filters;
using xNet;
using Leaf.xNet.Services;
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
                using (var avtoreg = new xNet.HttpRequest())
                {
                    string link = avtoreg.Get("https://oauth.vk.com/token?grant_type=password&client_id=2274003&client_secret=hHbZxrka2uZ6jB1inYsH&username=" + txtLogin.Text + "&password=" + txtPassword.Text).ToString(); //отправляем Get запрос 
                    dynamic json = JObject.Parse(link);
                    APIKEY.USER_TOKEN = json.access_token;
                    APIKEY.USER_ID = json.user_id;
                    APIKEY.USER_DOMAIN = json.domain;
                    APIKEY.login = txtLogin.Text;
                    APIKEY.password = txtPassword.Text;
                    MessageBox.Show(APIKEY.ACCES_TOKEN, APIKEY.USER_ID);
                    if (APIKEY.USER_TOKEN != null && APIKEY.USER_ID != null)
                    {
                        Model.RequestHistory request = new RequestHistory()
                        {
                            DateRequest = DateTime.Now,
                            TypeRequest = "auth",
                            idUser = APIKEY.USER_ID,
                            LoginUser = APIKEY.login
                        };
                        BD_Connection.bd.RequestHistory.Add(request);
                        BD_Connection.bd.SaveChanges();
                        MainWindow main = new MainWindow();
                        main.Show();
                    }
                    else
                    {
                        MessageBox.Show("error");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "пароль или лоигн введены не верно");
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
