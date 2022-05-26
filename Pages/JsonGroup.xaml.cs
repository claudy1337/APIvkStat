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
    /// Lógica de interacción para NotesPage.xaml
    /// </summary>
    public partial class NotesPage : Page
    {
       
        public String ResponceContentVisible
        {
            get { return (String)GetValue(ResponceContentPropertys); }
            set { SetValue(ResponceContentPropertys, value); }
        }
        public static readonly DependencyProperty ResponceContentPropertys =
            DependencyProperty.Register("ResponceContentVisible", typeof(String), typeof(MainWindow));

        public ObservableCollection<VKGroupMember> Members { get; set; }
            = new ObservableCollection<VKGroupMember>();
        public NotesPage()
        {
            InitializeComponent();
        }

        private async void getUser_Click(object sender, RoutedEventArgs e)
        {
            ResponceContentVisible = "....";
            var result = await Utility.FetchMembersInfo(txtGroupId.Text, txtCount.Text);
            ResponceContentVisible = Utility.PrettyJson(result.rawContent);
            txtResponce.Text = ResponceContentVisible;
            Members.Clear();
            var history = JsonConvert.DeserializeObject<Users.Root>(txtResponce.Text);
            Model.RequestHistory request = new RequestHistory()
            {
                DateRequest = DateTime.Now,
                TypeRequest = "groups.getMembers",
                idUser = APIKEY.USER_ID,
                LoginUser = APIKEY.login
            };
            BD_Connection.bd.RequestHistory.Add(request);
            BD_Connection.bd.SaveChanges();
        }

        private void savefile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile1 = new SaveFileDialog();
            saveFile1.DefaultExt = "*.json";
            saveFile1.Filter = "Test files|*.json";
            if (saveFile1.ShowDialog() == true &&
                saveFile1.FileName.Length > 0)
            {
                using (StreamWriter sw = new StreamWriter(saveFile1.FileName, true))
                {
                    sw.WriteLine(txtResponce.Text);
                    sw.Close();
                }
            }
            
           
        }

    }
    
}
