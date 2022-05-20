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


namespace UIKitTutorials.Pages
{
    /// <summary>
    /// Lógica de interacción para SoundsPage.xaml
    /// </summary>
    public partial class SoundsPage : Page
    {
        public String ResponceContents
        {
            get { return (String)GetValue(ResponceContentPropert); }
            set { SetValue(ResponceContentPropert, value); }
        }
        public static readonly DependencyProperty ResponceContentPropert =
            DependencyProperty.Register("ResponceContentVisible", typeof(String), typeof(MainWindow));
        public ObservableCollection<MessageMember> Members { get; set; }
            = new ObservableCollection<MessageMember>();
        public SoundsPage()
        {
            InitializeComponent();
        }

        private async void messageGet_Click(object sender, RoutedEventArgs e)
        {
            ResponceContents = "....";
            var result = await Utility.FetchMessageGet(APIKEY.USER_TOKEN, "all");
            ResponceContents = Utility.PrettyJson(result.rawMessage);
            txtResponce.Text = ResponceContents;
            Members.Clear();
            var usr = JsonConvert.DeserializeObject<Users.Root>(txtResponce.Text);
        }
    }
}
