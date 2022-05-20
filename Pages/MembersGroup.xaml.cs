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
    /// Lógica de interacción para HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            ResponceContent = null;
        }
        public String ResponceContent
        {
            get { return (String)GetValue(ResponceContentProperty); }
            set { SetValue(ResponceContentProperty, value); }
        }
        public static readonly DependencyProperty ResponceContentProperty =
            DependencyProperty.Register("ResponceContent", typeof(String), typeof(MainWindow));


        public ObservableCollection<VKGroupMember> Members { get; set; }
            = new ObservableCollection<VKGroupMember>();

        private async void GetUser_Click(object sender, RoutedEventArgs e)
        {
            ResponceContent = "....";
            var result = await Utility.FetchMembersInfo(txtGroupId.Text, txtCount.Text);
            ResponceContent = Utility.PrettyJson(result.rawContent);
            txtResponce.Text = ResponceContent;
            Members.Clear();
            
            try
            {
                var usr = JsonConvert.DeserializeObject<Users.Root>(txtResponce.Text);
                usersGroup.Text = $"подписч:\n{usr.response.count.ToString()}";
                usrList.ItemsSource = usr.response.items;
            }
            catch (System.NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void SaveUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void usrList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedUser = usrList.SelectedItem as Users.User;
            MessageBox.Show(selectedUser.domain);
            
        }
    }
}
