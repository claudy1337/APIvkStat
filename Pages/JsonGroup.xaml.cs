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
        public String ResponceContent
        {
            get { return (String)GetValue(ResponceContentProperty); }
            set { SetValue(ResponceContentProperty, value); }
        }
        public static readonly DependencyProperty ResponceContentProperty =
            DependencyProperty.Register("ResponceContent", typeof(String), typeof(MainWindow));

        public ObservableCollection<VKGroupMember> Members { get; set; }
            = new ObservableCollection<VKGroupMember>();
        public NotesPage()
        {
            InitializeComponent();
        }

        private async void getUser_Click(object sender, RoutedEventArgs e)
        {
            ResponceContent = "....";
            var result = await Utility.FetchMembersInfo(txtGroupId.Text, txtCount.Text);
            ResponceContent = Utility.PrettyJson(result.rawContent);
            txtResponce.Text = ResponceContent;
            Members.Clear();
            var usr = JsonConvert.DeserializeObject<Users.Root>(txtResponce.Text); 
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
